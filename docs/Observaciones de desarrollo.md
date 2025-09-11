# Observaciones de desarrollo

- **Recomendación:** Para la mayoría de los proyectos con Entity Framework, **la Opción A (sobrescribir `SaveChangesAsync`) es la más limpia y mantenible.** Mantiene la lógica centralizada en tu código C#, que es donde EF gestiona el resto de tus reglas de negocio.
- **`UnitPrice`:** Guardar el precio al momento de la venta es **crítico**. Si solo te basaras en el precio del producto, y este cambiara en el futuro, todos tus reportes de ventas históricos serían incorrectos. Has creado una "foto" del precio, lo cual es perfecto.