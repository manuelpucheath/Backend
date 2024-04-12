- Puerto Backend: 5267

- Agregar ConnectionString de SQL Server en el archivo Program.cs linea 24

- En la carpeta Migrations se encuentra la migración con todas las tablas requeridas incluyendo el procedimiento almacenado para consultar la tabla personas.
Una vez agregado el ConnectionString, ejecutar en la terminal el comando "dotnet ef database update"
