# Plantilla para Pull Request

### ¿Qué se hizo?

* Se implementó la lógica para consultar la base de datos y obtener todos los productos.
* Se creó la ruta `GET /api/products`.
* Se añadieron pruebas unitarias para el nuevo servicio.

### ¿Por qué se hizo?
* Para cumplir con el requerimiento HU-005 que pide mostrar el catálogo de productos en la página principal.
* Esto desbloquea el trabajo del equipo de frontend para que puedan consumir esta información.

### ¿Cómo probar los cambios?
1.  Ir a la rama `feature/get-products`.
2.  Ejecutar `npm install` para instalar las nuevas dependencias.
3.  Iniciar el servidor.
4.  Usar una herramienta como Postman o Insomnia para hacer una petición `GET` a `http://localhost:3000/api/products`.
5.  Verificar que la respuesta sea un arreglo de productos y el código de estado sea 200.

**Screenshots (si aplica)**
**(Opcional) Ticket relacionado:**
* [Link al ticket de Jira, Trello, o la herramienta que usen. Ejemplo: JIRA-123]



# Plantilla - Develop hacia Main

## Release v1.1.0 🎉

Este lanzamiento incluye las siguientes actualizaciones:

### ✨ Nuevas Funcionalidades
* Se añade la capacidad de consultar la lista de productos desde la API. (#123)
* Los usuarios ahora pueden filtrar productos por categoría. (#125)

### 🐛 Correcciones de Errores
* Se corrigió un error que causaba un cálculo incorrecto en el total del carrito. (#124)

### ⚙️ Mejoras
* Se mejoró el rendimiento de la consulta a la base de datos de productos.