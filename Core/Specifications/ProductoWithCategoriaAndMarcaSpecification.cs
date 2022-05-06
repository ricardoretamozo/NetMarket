using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductoWithCategoriaAndMarcaSpecification : BaseSpecification<Producto>
    {
        public ProductoWithCategoriaAndMarcaSpecification(ProductoSpecificationParams productoParams) 
            : base( x => 
                (string.IsNullOrEmpty(productoParams.Search) || x.Nombre.Contains(productoParams.Search)) &&
                (!productoParams.marcaId.HasValue || x.MarcaId == productoParams.marcaId) &&
                         (!productoParams.categoriaId.HasValue || x.CategoriaId == productoParams.categoriaId)) 
        {
            AddInclude(p => p.Categoria);
            AddInclude(p => p.Marca);
            //AddOrderBy(p => p.Nombre);
            //ApplyPaging(0,5);
            ApplyPaging(productoParams.PageSize * (productoParams.PageIndex-1), productoParams.PageSize);
            if (!string.IsNullOrEmpty(productoParams.sort))
            {
                switch (productoParams.sort)
                {
                    case "nombreAsc":
                        AddOrderBy(p => p.Nombre);
                        break;
                    case "nombreDesc":
                        AddOrderByDescending(p => p.Nombre);
                        break;
                    case "precioAsc":
                        AddOrderBy(p => p.Precio);
                        break;
                    case "precioDesc":
                        AddOrderByDescending(p => p.Precio);
                        break;
                    case "descripcionAsc":
                        AddOrderBy(p => p.Descripcion);
                        break;
                    case "descripcionDesc":
                        AddOrderByDescending(p => p.Descripcion);
                        break;
                    default:
                        AddOrderBy(p => p.Id);
                        break;
                }
            }
        }

        public ProductoWithCategoriaAndMarcaSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(p => p.Categoria);
            AddInclude(p => p.Marca);
        }
        
        
    }
}