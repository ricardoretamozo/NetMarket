using Core.Entities;

namespace Core.Specifications
{
    public class ProductoForCountingSpecification: BaseSpecification<Producto>
    {
        public ProductoForCountingSpecification(ProductoSpecificationParams productoParams)
            : base(x => 
                (string.IsNullOrEmpty(productoParams.Search) || x.Nombre.Contains(productoParams.Search)) &&
                (!productoParams.marcaId.HasValue || x.MarcaId == productoParams.marcaId) &&
                        (!productoParams.categoriaId.HasValue || x.CategoriaId == productoParams.categoriaId))
        {
            
        }

    }
}