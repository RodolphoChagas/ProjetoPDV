using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPDVModel
{
    public class CertificadoDigital
    {

        private static CertificadoDigital _instancia;
        private X509Certificate2 _oCertificado;
        private string _sSubject;
        private DateTime _dValidadeInicial;
        private DateTime _dValidadeFinal;


        public X509Certificate2 oCertificado
        {
            get { return _oCertificado; }
            set { _oCertificado = value; }
        }

        public string sSubject
        {
            get { return _sSubject; }
            set { _sSubject = value; }
        }

        public DateTime dValidadeInicial
        {
            get { return _dValidadeInicial; }
            set { _dValidadeInicial = value; }
        }

        public DateTime dValidadeFinal
        {
            get { return _dValidadeFinal; }
            set { _dValidadeFinal = value; }
        }



        private CertificadoDigital()
        {
        }


        public static CertificadoDigital getInstance
        {
            get
            {
                if (_instancia == null)
                {
                    return _instancia = new CertificadoDigital();
                }
                return _instancia;
            }
        }

        public void Seleciona_Certificado()
        {
            try
            {
                
                oCertificado = new X509Certificate2(@"C:\SISTEMAS\Certificado\Succo.pfx", "succo1", X509KeyStorageFlags.Exportable);
                //(@"C:\SISTEMAS\Certificado\Succo.pfx", "succo1", X509KeyStorageFlags.Exportable);

                _sSubject = oCertificado.Subject;
                _dValidadeInicial = oCertificado.NotBefore;
                _dValidadeFinal = oCertificado.NotAfter;

                


                //_oCertificado = new X509Certificate2();
                //X509Store store = new X509Store("MY", StoreLocation.CurrentUser);

                //store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

                //X509Certificate2Collection collection = store.Certificates;
                //X509Certificate2Collection collection1 = (collection.Find(X509FindType.FindByTimeValid, DateTime.Now, false));
                //X509Certificate2Collection collection2 = (collection.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, false));


                //_oCertificado = store.Certificates[1];
                //_sSubject = oCertificado.Subject;
                //_dValidadeInicial = oCertificado.NotBefore;
                //_dValidadeFinal = oCertificado.NotAfter;


                //_oCertificado = new X509Certificate2();
                //X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
                //store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

                //X509Certificate2Collection collection = store.Certificates;
                //X509Certificate2Collection collection1 = (collection.Find(X509FindType.FindByTimeValid, DateTime.Now, false));
                //X509Certificate2Collection collection2 = (collection.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, false));

                //_oCertificado = store.Certificates[1];
                //_sSubject = oCertificado.Subject;
                //_dValidadeInicial = oCertificado.NotBefore;
                //_dValidadeFinal = oCertificado.NotAfter;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Altera_Certificado(X509Certificate2 cert)
        {
            try
            {
                _oCertificado = cert;
                _sSubject = cert.Subject;
                _dValidadeInicial = cert.NotBefore;
                _dValidadeFinal = cert.NotAfter;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
