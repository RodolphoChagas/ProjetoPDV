using PetaPoco;
using ProjetoPDVDao;
using ProjetoPDVModel;
using ProjetoPDVServico;
using ProjetoPDVUtil;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ProjetoPDVUI
{
    public partial class frmSelecionaPagamento1 : Form
    {
        private List<PedidoPagamentoRel> _pedidoPagamentos = new List<PedidoPagamentoRel>();
        private List<TipoPagamento> _pagamentosSelecionados = new List<TipoPagamento>();
        private Pedido _pedido;
        private frmCaixaTouch _instanciaFrmCaixaTouch;
        private string urlQRCode;


        public frmSelecionaPagamento1(Pedido pedido, frmCaixaTouch frm)
        {
            InitializeComponent();

            _pedido = pedido;
            _instanciaFrmCaixaTouch = frm;

            foreach (Control control in pnlTipoPagamento.Controls)
            {
                if (control is Button button)
                    button.MouseDown += ControlsPanelSelecionaPagamento_MouseDown;
            }
        }

        private Operacao RetornaOperacao(int numParcelas = 0)
        {
            var operacaoDao = new OperacaoDao();

            int iCodOperacao = 0;


            if (numParcelas == 3)
            {
                return operacaoDao.GetOperacao(3); // VENDA A VISTA
            }

            switch (numParcelas)
            {
                case 1:
                    iCodOperacao = 130; // VENDA - Cartao 1x
                    break;
                case 2:
                    iCodOperacao = 102; // VENDA - Cartao 2x
                    break;
                case 3:
                    iCodOperacao = 103; // VENDA - Cartao 3x
                    break;
                case 4:
                    iCodOperacao = 141; // VENDA - Cartao 4x
                    break;
                case 5:
                    iCodOperacao = 142; // VENDA - Cartao 5x
                    break;
                case 6:
                    iCodOperacao = 143; // VENDA - Cartao 6x
                    break;
                case 7:
                    iCodOperacao = 144; // VENDA - Cartao 7x
                    break;
                case 8:
                    iCodOperacao = 145; // VENDA - Cartao 8x
                    break;
                case 9:
                    iCodOperacao = 146; // VENDA - Cartao 9x
                    break;
                case 10:
                    iCodOperacao = 147; // VENDA - Cartao 10x
                    break;
            }

            return operacaoDao.GetOperacao(iCodOperacao);
        }


        private void VerificaStatusImpressora()
        {
            MP2032.ConfiguraModeloImpressora(7); // Bematech MP-4200 TH
            MP2032.IniciaPorta("USB");

            var codigoRetorno = MP2032.Le_Status();
            if (codigoRetorno == 0)
            {
                MessageBox.Show("Erro ao se comunicar com a Impressora Bematech MP-4200 TH, verifique por favor.", "** ATENÇÃO **", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (codigoRetorno == 5)
            {
                MessageBox.Show("Impressora com pouco papel, verifique por favor.", "** ATENÇÃO **", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (codigoRetorno == 9)
            {
                MessageBox.Show("Impressora com a tampa aberta, verifique por favor.", "** ATENÇÃO **", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MP2032.FechaPorta();
                return;
            }
            else if (codigoRetorno == 32)
            {
                MessageBox.Show("Impressora sem papel, verifique por favor.", "** ATENÇÃO **", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void FinalizaVenda(bool isEmitirNFCe, bool isBotaoFinalizarImprimir = false)
        {

            if (lstVWPagamentos.Items.Count == 0)
            {
                MessageBox.Show("Informe uma Forma de Pagamento por favor!", "Mensagem", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToDecimal(lblFalta.Text) > 0)
            {
                MessageBox.Show("Faltam R$ " + lblFalta.Text + " reais para finalizar o pagamento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            //Gambiarra pedida pelo cliente
            if (isBotaoFinalizarImprimir && lblFinalizarImprimir.ForeColor == Color.Gray)
            {
                lblFinalizarImprimir.ForeColor = Color.White;
                return;
            }

            //if ((MessageBox.Show("Confirma finalizar o pagamento ?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Information)) == DialogResult.No)
            //    return;


            InicializaCliente();

            VerificaStatusImpressora();


            var db = new Database("stringConexao");
            try
            {

                // Iniciando a transação
                db.BeginTransaction();

                _pedido.DataDigitacao = DateTime.Now;
                //_pedido.DataVencimento = DateTime.Now;
                //_pedido.pagamentos = _pagamentosInformados;
                _pedido.Operacao = RetornaOperacao(3);
                _pedido.OperacaoId = _pedido.Operacao.OperacaoId;
                _pedido.Pagamentos = _pagamentosSelecionados;
                _pedido.StatusNFCe = "0";
                //pedido.codcon = 0;
                //pedido.dscdoc = Convert.ToDecimal(lblDesconto.Text);
                //_pedido.valdsc = Convert.ToDecimal(lblDesconto.Text);
                _pedido.ValorPedido = Convert.ToDecimal(lblTotalAPagar.Text);
                _pedido.Troco = Convert.ToDecimal(lblTroco.Text);
                _pedido.StatusPedido = "F";


                //if (isEmitirNFCe)
                //{
                //    _pedido.NFiscal = ((new ControleFiscalDao()).GetUltimoNumeroNFiscalGerado() + 1);
                //    db.Update("Update Controle Set NFiscal=" + _pedido.NFiscal + " Where ChvControle = 1");
                //}

                // Inserindo o pedido
                _pedido.NumDoc = Convert.ToInt32(db.Insert(_pedido));

                //Inserindo os Itens do pedido
                db.Insert_lstPedidos(_pedido.NumDoc, _pedido.ItensDoPedido);

                //Inserindo os pagamentos do pedido
                foreach (TipoPagamento pagamento in _pagamentosSelecionados)
                {
                    db.Insert("Movdb_Pagamento_Rel", new { numdoc = _pedido.NumDoc, pagamento_id = pagamento.PagamentoId, valor = pagamento.ValorPago, observacao = pagamento.Observacao });
                }

                //Gerando pagamento
                //if (!Gera_Boleta(db))
                //    throw new Exception("");

                //Comitando o pedido
                db.CompleteTransaction();
            }
            catch (Exception ex)
            {
                //RollBack
                db.AbortTransaction();
                MessageBox.Show("Houve um erro de conexão com o Banco de Dados." + Environment.NewLine + "Tente Novamente.." + Environment.NewLine + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (isEmitirNFCe)
            {
                //Gerando o XML de Nota Fiscal Eletronica(NFC-e)
                if (Gera_NFCe())
                {
                    try
                    {
                        if (!ImpressoraBematech.isImprimeDanfeNFCe(_pedido, urlQRCode))
                            throw new Exception("Houve um erro inesperado ao se comunicar com a IMPRESSOSA BEMATECH, verifique-a por favor!");


                        //MessageBox.Show("NFC-e emitida com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("** NOTA EMITIDA **" + Environment.NewLine + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                try
                {
                    if (!ImpressoraBematech.isImprimeComprovante(_pedido))
                        throw new Exception("Houve um erro inesperado ao se comunicar com a IMPRESSOSA BEMATECH, verifique-a por favor!");


                    //MessageBox.Show("Pedido Finalizado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Pedido finalizado mas houve um erro ao se comunicar com a IMPRESSOSA BEMATECH, verifique-a por favor!" + Environment.NewLine + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Close();
            _instanciaFrmCaixaTouch.IniciaNovaVenda();
        }


        private void lstVWPagamentos_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstVWPagamentos.FocusedItem == null)
                return;

            try
            {
                if (MessageBox.Show("Deseja estornar esse pagamento ?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    return;

                var valorEstornado = Convert.ToDecimal(lstVWPagamentos.FocusedItem.SubItems[2].Text);

                _pagamentosSelecionados.RemoveAt(lstVWPagamentos.FocusedItem.Index);

                AtualizaValores(valorEstornado * -1);
                AtualizaListaDePagamentos(_pagamentosSelecionados);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao tentar estornar o pagamento selecionado, tente novamente!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        private void AtualizaListaDePagamentos(List<TipoPagamento> pagamentos)
        {
            try
            {
                lstVWPagamentos.Items.Clear();

                var isDinheiro = false;
                var isCartao = false;

                foreach (TipoPagamento pagamento in pagamentos)
                {
                    var ls = new ListViewItem(pagamento.PagamentoId.ToString());

                    ls.UseItemStyleForSubItems = false;
                    ls.SubItems.Add(pagamento.Descricao);
                    ls.SubItems.Add(pagamento.ValorPago.ToString("0.00"));
                    ls.SubItems.Add(pagamento.Observacao.Trim());
                    ls.SubItems.Add("Excluir").ForeColor = Color.Brown;
                    

                    lstVWPagamentos.Items.Add(ls);

                    // Gambiarra pedida pelo Cliente
                    if (pagamento.Descricao.Equals("Dinheiro"))
                        isDinheiro = true;
                    else
                    {
                        isCartao = true;

                        pictureBox2.Visible = false;
                        lblFinalizar.Visible = false;

                        //pictureBox3.Enabled = true;
                        //lblFinalizarImprimir.Enabled = true;

                        lblFinalizarImprimir.ForeColor = Color.White;
                    }

                    if(isDinheiro && !isCartao)
                    {
                        pictureBox2.Visible = true;
                        lblFinalizar.Visible = true;

                        //pictureBox3.Enabled = false;
                        //lblFinalizarImprimir.Enabled = false;

                        lblFinalizarImprimir.ForeColor = Color.Gray;
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Erro inesperado ao listar a forma de pagamento!");
            }
        }

        private void AtualizaValores(decimal valorPago = 0)
        {
            lblTotalAPagar.Text = _pedido.ValorPedido.ToString("0.00");
            lblTotalPago.Text = (Convert.ToDecimal(lblTotalPago.Text) + valorPago).ToString("0.00");

            if (Convert.ToDecimal(lblTotalPago.Text) > Convert.ToDecimal(lblTotalAPagar.Text))
            {
                lblFalta.Text = "0,00";
                lblTroco.Text = (Convert.ToDecimal(lblTotalPago.Text) - Convert.ToDecimal(lblTotalAPagar.Text)).ToString("0.00");
            }
            else
            {
                lblTroco.Text = "0,00";
                lblFalta.Text = (_pedido.ValorPedido - Convert.ToDecimal(lblTotalPago.Text)).ToString("0.00");
            }
        }

        private void ControlsPanelSelecionaPagamento_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (sender is Button btn)
                {
                    var frm = new frmInformaPagamento(btn.Tag.ToString(), Convert.ToDecimal(lblFalta.Text));
                    frm.ShowDialog();

                    if (frm.Pagamento != null)
                    {
                        //_pedidoPagamentos.Add(new PedidoPagamentoRel { PagamentoId = frm.Pagamento.PagamentoId, ValorPago = frm.Pagamento.ValorPago, Observacao = frm.Pagamento.Observacao, TipoPagamento = frm.Pagamento });
                        _pagamentosSelecionados.Add(frm.Pagamento);

                        AtualizaValores(frm.Pagamento.ValorPago);
                        AtualizaListaDePagamentos(_pagamentosSelecionados);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Erro inesperado ao usar o Painel de Teclado!");
            }
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lblCancelar_Click(sender, e);
        }

        private void frmSelecionaPagamento1_Load(object sender, EventArgs e)
        {
            AtualizaValores();
        }


        // ========================================================================
        private bool Gera_NFCe()
        {

            var xmlNFCe = new XmlDocument();
            var xmlNFCeAssinado = new XmlDocument();

            var gerarXml = new GeraXml();
            var assinarXml = new AssinaXml();
            var validarXml = new ValidaXml();
            var transmitirXml = new TransmiteXml();
            //Email email = new Email();
            var xmlDao = new XmlDao();

            StreamWriter Grava;

            string retValidar;
            string strProc;
            string strXmlProcNfe;
            string retTransmitir;
            string cStatus_LoteProcessado;
            string cStatus_Autorizado;

            int nPosI;
            int nPosF;

            try
            {

                retTransmitir = string.Empty;
                retValidar = string.Empty;

                cStatus_LoteProcessado = string.Empty;
                cStatus_Autorizado = string.Empty;


                _pedido.NFiscal = ((new ControleFiscalDao()).GetUltimoNumeroNFiscalGerado() + 1);

                try
                {

                    // Gerando o XML
                    xmlNFCe = (gerarXml.GeraXmlNFCe(_pedido));

                    //MensagemSistema("Arquivo Gerado ...", Color.OliveDrab);

                    // Assinando o XML
                    xmlNFCeAssinado = assinarXml.AssinaXML(xmlNFCe.InnerXml, "infNFe", CertificadoDigital.getInstance.oCertificado);
                }
                catch (Exception ex)
                {
                    //Log_Exception.Monta_ArquivoLog(ex);
                    //MensagemSistema("** Erro ao ASSINAR XML NFC-e, tente novamente **", Color.Brown);
                    MessageBox.Show("Erro ao tentar gerar e assinar o xml  da NFC-e" + Environment.NewLine + "Erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //MensagemSistema("Arquivo Assinado ...", Color.OliveDrab);



                if (GeraXml.AmbienteNFCe == "2")
                {
                    //Salvando o arquivo XML na pasta
                    Grava = File.CreateText(@"C:\Users\Comercial\Desktop\ASSINADO.xml");
                    Grava.Write(xmlNFCeAssinado.InnerXml);
                    Grava.Close();
                }


                try
                {
                    // Validando o XML
                    retValidar = validarXml.Valida(xmlNFCeAssinado, "NFe");
                    urlQRCode = gerarXml.GetUrlQRCode(xmlNFCeAssinado, _pedido);

                    //Inserindo a URL QRCode no xml já assinado
                    xmlNFCeAssinado.LoadXml(xmlNFCeAssinado.InnerXml.Replace("</infNFe>", "</infNFe><infNFeSupl><qrCode><![CDATA[" + urlQRCode + "]]></qrCode><urlChave>http://www4.fazenda.rj.gov.br/consultaNFCe/QRCode</urlChave></infNFeSupl>"));
                }
                catch (Exception ex)
                {
                    //Log_Exception.Monta_ArquivoLog(ex);

                    //MensagemSistema("** Erro ao VALIDAR XML NFC-e **", Color.Brown);
                    MessageBox.Show("Erro ao tentar validar o xml da NFC-e " + Environment.NewLine + "Erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (retValidar == string.Empty)
                {
                    try
                    {
                        //MensagemSistema("Enviando a NFC-e", Color.OliveDrab);

                        // Recebendo o XML de retorno da transmissão
                        retTransmitir = transmitirXml.XML_NFCe4(xmlNFCeAssinado, _pedido.NFiscal.ToString(), CertificadoDigital.getInstance.oCertificado);

                        if (retTransmitir.Substring(0, 4) != "Erro")
                        {
                            XmlDocument xmlRetorno = new XmlDocument();
                            xmlRetorno.LoadXml(retTransmitir);

                            // Lote processado
                            if (xmlRetorno.GetElementsByTagName("cStat")[0].InnerText == "104")
                            {
                                // Autorizado
                                if (xmlRetorno.GetElementsByTagName("cStat")[1].InnerText == "100")
                                {
                                    try
                                    {
                                        //MensagemSistema("Autorizado o uso da NFC-e", Color.OliveDrab);

                                        _pedido.Chave = xmlRetorno.GetElementsByTagName("chNFe")[0].InnerText;
                                        _pedido.Protocolo = xmlRetorno.GetElementsByTagName("nProt")[0].InnerText;

                                        // Separar somente o conteúdo a partir da tag <protNFe> até </protNFe>
                                        nPosI = retTransmitir.IndexOf("<protNFe");
                                        nPosF = retTransmitir.Length - (nPosI + 13);
                                        strProc = retTransmitir.Substring(nPosI, nPosF);


                                        // XML pronto para salvar
                                        strXmlProcNfe = @"<?xml version=""1.0"" encoding=""utf-8"" ?><nfeProc xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""4.00"">" + xmlNFCeAssinado.InnerXml + strProc + "</nfeProc>";

                                        _pedido.Xml = new Xml()
                                        {
                                            NumDoc = _pedido.NumDoc,
                                            ArquivoXml = strXmlProcNfe,
                                            Data = DateTime.Now,
                                            Modelo = _pedido.ModeloNFiscal,
                                            StatNFCe = "100"
                                        };


                                        
                                        using (var db = new Database("stringConexao"))
                                        {
                                            db.BeginTransaction();

                                            try
                                            {
                                                db.Update("Update Controle Set NFiscal=" + _pedido.NFiscal + " Where ChvControle = 1");
                                                db.Update("Update Movdb Set data_nfiscal = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', NFiscal= " + _pedido.NFiscal + ", Chave='" + _pedido.Chave + "' ,Protocolo='" + _pedido.Protocolo + "', status_nfce = '" + _pedido.Xml.StatNFCe + "' Where NumDoc = " + _pedido.NumDoc);

                                                db.CompleteTransaction();
                                            }
                                            catch (Exception)
                                            {
                                                db.AbortTransaction();
                                            }
                                        }



                                        if (GeraXml.AmbienteNFCe == "2")
                                        {
                                            //Salvando o arquivo XML na pasta
                                            Grava = File.CreateText(@"C:\Users\Comercial\Desktop\EMITIDO.xml");
                                            Grava.Write(_pedido.Xml.ArquivoXml);
                                            Grava.Close();
                                        }

                                        if (GeraXml.AmbienteNFCe == "1")
                                        {
                                            if (!string.IsNullOrEmpty(ControleFiscal.GetInstance.CaminhoXmlAutorizado))
                                            {
                                                //Salvando o arquivo XML na pasta
                                                Grava = File.CreateText(ControleFiscal.GetInstance.CaminhoXmlAutorizado.Remove(ControleFiscal.GetInstance.CaminhoXmlAutorizado.Length - 1) + DateTime.Now.Month + @"\" + _pedido.Chave + "-procNfe.xml");
                                                Grava.Write(_pedido.Xml.ArquivoXml);
                                                Grava.Close();
                                            }
                                        }


                                        //Salva arquivo XML no Banco SQL (NFe)
                                        if (xmlDao.GravaXml(_pedido.Xml))
                                        {

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("NOTA EMITIDA, porém houve um erro ao inesperado ao salvar as informações no banco de dados " + Environment.NewLine + "Erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("O xml não pôde ser Autorizado! " + Environment.NewLine + "Motivo: " + xmlRetorno.GetElementsByTagName("xMotivo")[1].InnerText, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                            }
                            else
                            {
                                //MensagemSistema("Erro ao Transmitir(003) XML NFC-e para SEFAZ", Color.Brown);
                                MessageBox.Show("Erro no arquivo xml: " + Environment.NewLine + "Erro: " + xmlRetorno.GetElementsByTagName("xMotivo")[0].InnerText, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        else
                        {
                            //MensagemSistema("Erro ao Transmitir(002) XML NFC-e para SEFAZ", Color.Brown);
                            MessageBox.Show("Erro ao tentar transmitir o xml da NFC-e, tente novamente " + Environment.NewLine + "Erro: " + retTransmitir, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        //Log_Exception.Monta_ArquivoLog(ex);
                        //MensagemSistema("Erro ao Transmitir(001) XML NFC-e para SEFAZ", Color.Brown);
                        MessageBox.Show("Erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    //MensagemSistema("Erro ao validar XML NFC-e", Color.Brown);
                    MessageBox.Show("Erro XML Shema: " + retValidar, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                //Log_Exception.Monta_ArquivoLog(ex);
                //MensagemSistema("Ocorreu um erro inesperado, informe ao administrador do sistema!", Color.Brown);
                MessageBox.Show("Erro : " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void lblFinalizar_Click(object sender, EventArgs e)
        {
            FinalizaVenda(false);
        }

        private void lblFinalizarImprimir_Click(object sender, EventArgs e)
        {
            FinalizaVenda(true, true);
        }

        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            InicializaCliente();
        }

        private void InicializaCliente()
        {
            try
            {
                var clienteDao = new ClienteDao();


                // CONSUMIDOR NÃO IDENTIFICADO
                if (txtClienteCpf.Text.Trim().Equals(""))
                {
                    _pedido.Cliente = clienteDao.GetClienteConsumidorNaoIdentificado();
                    _pedido.ClienteId = _pedido.Cliente.ClienteId;
                    return;
                }


                if (txtClienteCpf.Text.Trim().Length < 14)
                {
                    // Validando o CPF
                    if (!Validacao.IsCpf(txtClienteCpf.Text.Trim()))
                    {
                        MessageBox.Show("CPF inválido!");
                        return;
                    }
                }
                else
                {
                    // Validando o CNPJ
                    if (!Validacao.IsCnpj(txtClienteCpf.Text.Trim()))
                    {
                        MessageBox.Show("CNPJ inválido!");
                        return;
                    }
                }

                _pedido.Cliente = clienteDao.GetCliente(txtClienteCpf.Text.Trim());

                if (_pedido.Cliente == null)
                {
                    // Inserindo no banco e retornando o ID
                    _pedido.ClienteId = Convert.ToInt32(clienteDao.InsertCliente(txtClienteCpf.Text.Trim(), txtClienteNome.Text.Trim(), txtClienteEmail.Text.Trim()));
                    _pedido.Cliente = clienteDao.GetCliente(_pedido.ClienteId.ToString());
                }
                else
                {
                    _pedido.ClienteId = _pedido.Cliente.ClienteId;

                    txtClienteNome.Text = string.IsNullOrEmpty(_pedido.Cliente.Nome) ? "" : _pedido.Cliente.Nome;
                    txtClienteEmail.Text = string.IsNullOrEmpty(_pedido.Cliente.Nome) ? "" : _pedido.Cliente.Email;
                    //txtClienteCelular.Text = string.IsNullOrEmpty(_pedido.Cliente.Nome) ? "" : _pedido.Cliente.TelefoneComercial;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnVisaEletron_Click(object sender, EventArgs e)
        {

        }

        private void frmSelecionaPagamento1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Close();
            }
        }
    }
}
