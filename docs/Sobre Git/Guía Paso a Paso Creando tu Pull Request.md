### **Guía Paso a Paso: Creando tu Pull Request**



Sigue estos pasos para completar el proceso.



#### **Paso 1: Iniciar la creación del Pull Request**



En la imagen, GitHub te lo pone fácil. Verás una barra amarilla que dice "`feature/get-products` had recent pushes...".

- **Acción:** Haz clic en el botón verde que dice **"Compare & pull request"**.

Esto te llevará a una nueva pantalla para preparar tu propuesta de integración.

------



#### **Paso 2: Rellenar la información del Pull Request**



Esta es la parte más importante para comunicarte con tu equipo. Verás una pantalla para configurar tu PR.

1. **Revisar las ramas (Base y Compare):** Asegúrate de que las ramas estén correctas.

   - **`base: develop`**: Esta es la rama a la que quieres que se integren tus cambios. Generalmente es `develop` o `main`.
   - **`compare: feature/get-products`**: Esta es tu rama, la que contiene el código que trabajaste.

2. **Poner un Título:** Escribe un título claro y conciso que resuma lo que hiciste. Por ejemplo:

   - `feat: Implementa la obtención de productos desde la API`
   - `Crea el endpoint para listar productos`

3. **Añadir una Descripción:** En el cuadro de texto más grande, explica con más detalle los cambios que realizaste. Es una buena práctica responder a preguntas como:

   - **¿Qué hace este PR?** (Ej: "Este PR añade la funcionalidad para que el sistema pueda consultar la lista de productos.")
   - **¿Cómo se puede probar?** (Ej: "Para probarlo, hay que levantar el servidor y hacer una petición GET a `/api/products`.")
   - **¿Hay algo más que el revisor deba saber?** (Ej: "¿Se necesita alguna variable de entorno nueva? ¿Hay algún cambio en la base de datos?")

   Una buena descripción ayuda a que los demás entiendan tu trabajo rápidamente.

------



#### **Paso 3: Solicitar Revisiones (Opcional pero recomendado)**



En la parte derecha, verás opciones como **"Reviewers"** (Revisores), **"Assignees"** (Asignados), **"Labels"** (Etiquetas), etc.

- **Acción:** En la sección de **"Reviewers"**, selecciona a uno o más compañeros de tu equipo para que revisen tu código. Esto les enviará una notificación para que le echen un vistazo a tu trabajo, te den su opinión y aprueben los cambios.

------



#### **Paso 4: Crear el Pull Request**



Una vez que el título, la descripción y los revisores estén listos:

- **Acción:** Haz clic en el botón verde grande que dice **"Create pull request"**.

¡Y listo! 🎉 Has creado oficialmente tu propuesta.

------



### **¿Y ahora qué sigue? El Proceso de Revisión**



Una vez creado el PR, empieza un ciclo de colaboración:

1. **Discusión y Revisión:** Tus compañeros revisarán tu código. Pueden dejar comentarios, hacer preguntas o solicitar cambios directamente en los archivos que modificaste.
2. **Hacer Cambios (si es necesario):** Si te piden ajustes, simplemente haz los cambios en tu código local (en la rama `feature/get-products`), haz un nuevo `commit` y vuelve a hacer `push`. El Pull Request se actualizará automáticamente con los nuevos cambios.
3. **Aprobación:** Cuando tus compañeros estén conformes, aprobarán el Pull Request.
4. **Merge (Fusión):** Finalmente, alguien (generalmente tú o el líder del equipo) hará clic en el botón **"Merge pull request"**. Esto tomará todo el código de tu rama `feature/get-products` y lo integrará de forma definitiva en la rama `develop`.

Una vez que se hace el "merge", tu trabajo ya forma parte oficial del proyecto. ¡Felicidades!