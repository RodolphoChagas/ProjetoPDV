using ProjetoPDVModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPDVDao
{
    public class CapDao
    {

        public CapSubcategoria GetSubCategoria(int subCategoriaId)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<CapSubcategoria>("SELECT * FROM Cap_SubCategoria WHERE subcategoria_id=@0", subCategoriaId);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar a Abertura de Caixa do dia!" + ex.Message);
            }
        }

        public CapCategoria GetCategoria(int categoriaId)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<CapCategoria>("SELECT * FROM Cap_Categoria WHERE categoria_id=@0", categoriaId);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar a Abertura de Caixa do dia!" + ex.Message);
            }
        }


        public List<CapCategoria> GetCategoriasAtivas()
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).Query<CapCategoria>("SELECT * FROM Cap_Categoria WHERE status = 'A' ORDER BY descricao").ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<CapSubcategoria> GetSubcategoriasPorCategoria(int categoriaId)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).Query<CapSubcategoria>("SELECT * FROM Cap_SubCategoria WHERE status = 'A' AND categoria_id=@0 ORDER BY descricao", categoriaId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
