# Crud MVC

 Sistema básico con operaciones CRUD hecho en MVC .Net Core 3.1 y Entity Framework.

## ¿De qué trata esta aplicación?

Este proyecto consiste en un pequeño sistema de inventario con una base de datos 
lista para usar y lógica de negocio mínima. 
Todos los componentes usados en mayor o menos medida se listan a continuación

  - [Entity Framework Core 3.1.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/3.1.0) (back-end)
  - [datatables 1.13.3](https://datatables.net/) (front-end)
  - [FluentValidation.AspNetCore 11.0.0](https://www.nuget.org/packages/FluentValidation.AspNetCore/11.0.0) (back-end/front-end)

## ¿Cómo pruebo esto?

Para poder ejecutar la aplicación se necesita tener previamente instalado los siquientes 
programas

  - [SQL Server Express LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16)
  - IIS Express 10
  - [Net Core 3.1 runtime](https://dotnet.microsoft.com/en-us/download/dotnet/3.1)

## Modelo de datos

El modelo de datos de la aplicación cuenta con 2 entidades, Artículo y Categoría. Puede ver la relación 
entre estas en el archivo (.edmx) dentro de la aplicación. Aquí la representación gráfica del mismo

![Diagrama](Images/png/)
  
## Capturas

- Animación de una operación agregar/editar/eliminar artículo.  

  ![](Images/gif/article_crud_operation.gif)

- Pagina de lista de artículos.  

  ![](Images/png/articles-list_details-responsive.png)

- Página de detalles de un artículo.  

  ![](Images/png/article-details.png)
