using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuration
{
    //Configuracion base de la clase producto, en un clase diferente.
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        //Indicamos los requisitos de cara atributo de nuestra clase producto 
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            // objeto builder nos permitira aplicar las restriciones de nuestro objeto producto
            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Imagen).HasMaxLength(1000);
            
        }
    }
}