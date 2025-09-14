# **Otras consultas**

### **¿Por qué es bueno borrar la rama?**



1. **Mantiene el repositorio limpio:** Evita que el proyecto se llene de docenas de ramas viejas y ya fusionadas, lo que facilita la navegación y la búsqueda de ramas que sí están activas.
2. **Evita confusiones:** Impide que tú u otra persona reutilice una rama antigua por error. Una rama solo debe tener un propósito y, una vez cumplido, se desecha.
3. **El código no se pierde:** ¡No te preocupes! Todo tu trabajo ya está seguro e integrado en la rama principal (`develop` o `main`). Además, el historial completo de los cambios, comentarios y revisiones sigue disponible en el Pull Request (que ahora estará cerrado).

------



### **¿Qué hago si quiero arreglar o agregar algo?**



Esta es la parte más importante del flujo de trabajo: **Nunca reutilices una rama ya fusionada.** El proceso correcto es siempre crear una rama nueva a partir de la rama principal actualizada.



#### **Caso 1: Necesito arreglar un bug en la funcionalidad que acabo de entregar.**



Imagina que después de fusionar `feature/get-products`, descubres un error. El proceso es el siguiente:

1. **Asegúrate de tener la última versión:** Antes de hacer nada, actualiza tu copia local de la rama principal.

   Bash

   ```
   git checkout develop
   git pull origin develop
   ```

2. **Crea una rama NUEVA para el arreglo:** Nómbrala de forma descriptiva, indicando que es un arreglo (fix).

   Bash

   ```
   git checkout -b fix/product-list-cache-error
   ```

3. **Haz los cambios:** Corrige el bug en el código.

4. **Commit y Push:** Guarda tus cambios y súbelos al repositorio remoto en esta nueva rama.

   Bash

   ```
   git add .
   git commit -m "fix: Corrige el error de caché en la lista de productos"
   git push origin fix/product-list-cache-error
   ```

5. **Crea un NUEVO Pull Request:** Ve a GitHub (o la plataforma que uses) y abre un nuevo PR desde `fix/product-list-cache-error` hacia `develop`.



#### **Caso 2: Quiero agregar una mejora o algo nuevo relacionado.**



Supongamos que ahora quieres añadir filtros a la lista de productos que creaste. El flujo es exactamente el mismo.

1. **Actualiza tu rama `develop`:**

   Bash

   ```
   git checkout develop
   git pull origin develop
   ```

2. **Crea una rama NUEVA para la nueva funcionalidad:**

   Bash

   ```
   git checkout -b feature/add-product-filtering
   ```

3. **Trabaja en la mejora:** Añade el código para los filtros.

4. **Commit y Push:**

   Bash

   ```
   git commit -m "feat: Añade filtros por categoría y precio a la lista de productos"
   git push origin feature/add-product-filtering
   ```

5. **Crea otro NUEVO Pull Request.**



### **En Resumen: El Ciclo de Vida de una Rama**



Piensa en las ramas como herramientas desechables con un solo uso:

1. **Crear:** Se crea desde la rama principal (`develop`) para un trabajo específico.
2. **Usar:** Se trabaja en ella, se hacen commits y se sube.
3. **Fusionar:** Se integra en la rama principal a través de un Pull Request.
4. **Desechar:** Se elimina tanto del repositorio remoto como de tu máquina local.

Para limpiar la rama de tu máquina local, una vez que estés seguro de que se fusionó, puedes usar:

Bash

```
# Cambia a otra rama (no puedes borrar la rama en la que estás)
git checkout develop

# Borra la rama localmente
git branch -d feature/get-products
```