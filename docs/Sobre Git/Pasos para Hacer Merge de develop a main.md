

# Pasos para Hacer Merge de `develop` a `main`





#### **Paso 1: Asegurarte de que `develop` esté estable y actualizado**



Antes de si quiera pensar en tocar `main`, tienes que estar 100% seguro de que la rama `develop` funciona perfectamente.

1. **Actualiza tu rama `develop` local:** Asegúrate de tener la última versión de la rama, con todas las funcionalidades ya integradas y probadas.

   Bash

   ```
   git checkout develop
   git pull origin develop
   ```

2. **Pruebas Finales:** Este es el momento de correr todas las pruebas automáticas y hacer una verificación manual final en el entorno de pruebas (`staging` o `testing`) para confirmar que la integración de todas las features no rompió nada.



#### **Paso 2: Iniciar el Pull Request (PR) de `develop` hacia `main`**



El proceso es el mismo, pero cambiando las ramas.

1. Ve a la sección de "Pull Requests" en GitHub (o tu plataforma).

2. Haz clic en "New pull request".

3. **¡Esta es la parte más importante!** Configura las ramas de la siguiente manera:

   - **`base: main`** ← (La rama que recibirá el código).
   - **`compare: develop`** ← (La rama que tiene los cambios).

   La plataforma te mostrará todos los commits y cambios que se van a integrar en `main`.



#### **Paso 3: Rellenar el Título y la Descripción (Release Notes)**



El PR de `develop` a `main` es especial. Su descripción funciona como un resumen de todo lo que se va a lanzar, conocido como **"Release Notes"** (Notas de la Versión).

- **Título del PR:** Debe ser claro y conciso, usualmente indica la nueva versión que se está lanzando.

  - Ejemplo: `Release v1.1.0`
  - Ejemplo: `Lanzamiento de nuevas funcionalidades de productos`

- **Descripción del PR:** Aquí no describes los detalles técnicos, sino que resumes las nuevas características, arreglos y cambios desde la última vez que se actualizó `main`. Es un resumen para todo el equipo (e incluso para marketing o ventas).

  - **Buena plantilla:**

    Markdown

    ```
    ## Release v1.1.0 🎉
    
    Este lanzamiento incluye las siguientes actualizaciones:
    
    ### ✨ Nuevas Funcionalidades
    * Se añade la capacidad de consultar la lista de productos desde la API. (#123)
    * Los usuarios ahora pueden filtrar productos por categoría. (#125)
    
    ### 🐛 Correcciones de Errores
    * Se corrigió un error que causaba un cálculo incorrecto en el total del carrito. (#124)
    
    ### ⚙️ Mejoras
    * Se mejoró el rendimiento de la consulta a la base de datos de productos.
    ```

  Muchas plataformas pueden autogenerar esta lista a partir de los títulos de los PRs que se han ido fusionando a `develop`.



#### **Paso 4: Revisión y Merge**



La revisión de este PR suele ser más de alto nivel. Un líder de equipo o el arquitecto principal darán el visto bueno final para asegurarse de que todo lo planeado está incluido.

Una vez aprobado, haz clic en **"Merge pull request"**. Es muy común usar la opción por defecto ("Merge Commit") en este caso para mantener un historial claro de cuándo ocurrió cada lanzamiento.

------



### ## ¿Y después del merge? ¡No has terminado!



Hacer el merge a `main` va acompañado de un paso crucial: **crear un tag**.

Un **tag** es una etiqueta o una marca permanente en la historia de tu repositorio que apunta a un commit específico. Se usa para señalar las versiones oficiales de tu software.

1. **Actualiza tu rama `main` local:**

   Bash

   ```
   git checkout main
   git pull origin main
   ```

2. **Crea el tag:** Nómbralo igual que la versión que definiste en el PR.

   Bash

   ```
   git tag -a v1.1.0 -m "Release version 1.1.0"
   ```

   - `v1.1.0` es el nombre del tag.
   - `-m "..."` es el mensaje asociado al tag.

3. **Sube el tag al repositorio remoto:** Por defecto, los tags no se suben con `git push`. Debes hacerlo explícitamente.

   Bash

   ```
   git push origin --tags
   ```

¡Ahora sí! Tu código está en `main` y tienes una marca (`v1.1.0`) que te permitirá volver a esta versión exacta del código en cualquier momento.