# Guía de Creación y Gestión de Ramas (Branches)

## 📋 Índice

1. [Introducción](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#introducción)
2. [Estrategia de Branching](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#estrategia-de-branching)
3. [Nomenclatura de Ramas](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#nomenclatura-de-ramas)
4. [Tipos de Ramas](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#tipos-de-ramas)
5. [Workflow Recomendado](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#workflow-recomendado)
6. [Comandos Esenciales](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#comandos-esenciales)
7. [Mejores Prácticas](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#mejores-prácticas)
8. [Resolución de Conflictos](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#resolución-de-conflictos)
9. [Ejemplos Prácticos](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#ejemplos-prácticos)
10. [Checklist](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#checklist)

## Introducción

Una buena estrategia de branching es fundamental para el desarrollo colaborativo. Este manual establece las reglas para crear, nombrar y gestionar ramas de manera consistente y eficiente.

### ¿Por qué usar ramas?

- **Desarrollo paralelo**: Múltiples funcionalidades simultáneas
- **Aislamiento**: Cambios experimentales sin afectar el código principal
- **Colaboración**: Cada desarrollador puede trabajar independientemente
- **Estabilidad**: Mantener la rama principal siempre funcional
- **Revisión**: Facilita el code review antes de integrar cambios

## Estrategia de Branching

### Modelo Git Flow Simplificado

```
main (producción)
├── develop (desarrollo)
│   ├── feature/nueva-funcionalidad
│   ├── feature/otra-funcionalidad
│   └── bugfix/corregir-error
├── hotfix/error-critico
└── release/v2.1.0
```

### Ramas Principales

#### `main` (o `master`)

- **Propósito**: Código en producción
- **Estabilidad**: Siempre debe estar funcional
- **Protección**: Solo merge de release y hotfix
- **Deploy**: Automático a producción

#### `develop`

- **Propósito**: Rama de integración de desarrollo
- **Contenido**: Últimas funcionalidades completadas
- **Origen**: Base para todas las features
- **Destino**: Se mergea a release

## Nomenclatura de Ramas

### Formato General

```
<tipo>/<descripción-corta>
<tipo>/<número-issue>-<descripción-corta>
<tipo>/<desarrollador>/<descripción>
```

### Reglas de Nomenclatura

1. **Minúsculas**: Solo letras minúsculas
2. **Guiones**: Usar guiones (-) para separar palabras
3. **Descriptivo**: Claro y conciso
4. **Sin espacios**: Reemplazar espacios con guiones
5. **Prefijo obligatorio**: Siempre incluir tipo de rama
6. **Máximo 40 caracteres**: Para mantener legibilidad

### Caracteres Permitidos

- ✅ Letras minúsculas (a-z)
- ✅ Números (0-9)
- ✅ Guiones (-)
- ✅ Barras (/) para separar tipo
- ❌ Espacios
- ❌ Caracteres especiales (&, @, #, etc.)
- ❌ Mayúsculas
- ❌ Tildes o acentos

## Tipos de Ramas

### 🚀 Feature (Funcionalidades)

**Propósito**: Desarrollo de nuevas funcionalidades

```bash
# Formato
feature/<descripción>
feature/<issue>-<descripción>

# Ejemplos
feature/login-oauth
feature/123-sistema-pagos
feature/dashboard-analytics
feature/user-profile-settings
```

**Ciclo de vida**:

- Se crea desde: `develop`
- Se mergea a: `develop`
- Se elimina: Después del merge

### 🐛 Bugfix (Corrección de Errores)

**Propósito**: Corregir errores no críticos encontrados en desarrollo

```bash
# Formato
bugfix/<descripción>
bugfix/<issue>-<descripción>

# Ejemplos
bugfix/email-validation
bugfix/456-memory-leak
bugfix/responsive-layout
bugfix/form-submission-error
```

**Ciclo de vida**:

- Se crea desde: `develop`
- Se mergea a: `develop`
- Se elimina: Después del merge

### 🔥 Hotfix (Corrección Crítica)

**Propósito**: Corregir errores críticos en producción

```bash
# Formato
hotfix/<descripción>
hotfix/<versión>-<descripción>

# Ejemplos
hotfix/payment-gateway-down
hotfix/v1.2.1-security-patch
hotfix/database-connection
hotfix/critical-login-error
```

**Ciclo de vida**:

- Se crea desde: `main`
- Se mergea a: `main` y `develop`
- Se elimina: Después del merge

### 📦 Release (Preparación de Lanzamiento)

**Propósito**: Preparar una nueva versión para producción

```bash
# Formato
release/<versión>
release/<versión>-<nombre>

# Ejemplos
release/v2.1.0
release/v1.5.0-summer-update
release/2024-sprint-1
```

**Ciclo de vida**:

- Se crea desde: `develop`
- Se mergea a: `main` y `develop`
- Se elimina: Después del merge

### 🧪 Experimental (Pruebas y Experimentos)

**Propósito**: Pruebas experimentales o spikes técnicos

```bash
# Formato
experimental/<descripción>
spike/<descripción>

# Ejemplos
experimental/new-architecture
spike/react-to-vue-migration
experimental/ai-integration
spike/performance-optimization
```

**Ciclo de vida**:

- Se crea desde: `develop`
- Destino: Variable (puede no mergearse)
- Se elimina: Al finalizar el experimento

### 🔧 Chore (Tareas de Mantenimiento)

**Propósito**: Configuración, dependencias, herramientas

```bash
# Formato
chore/<descripción>

# Ejemplos
chore/update-dependencies
chore/setup-ci-pipeline
chore/configure-eslint
chore/docker-optimization
```

### 👤 Ramas Personales (Opcional)

**Propósito**: Desarrollo personal antes de feature oficial

```bash
# Formato
<nombre>/<tipo>/<descripción>

# Ejemplos
juan/feature/user-dashboard
maria/bugfix/email-template
carlos/experimental/new-ui
```

## Workflow Recomendado

### 🔄 Flujo Estándar para Features

#### 1. Crear la rama

```bash
# Actualizar develop
git checkout develop
git pull origin develop

# Crear nueva rama feature
git checkout -b feature/nueva-funcionalidad
```

#### 2. Desarrollar

```bash
# Hacer cambios y commits
git add .
git commit -m "feat: implementar base de nueva funcionalidad"

# Subir rama al repositorio
git push -u origin feature/nueva-funcionalidad
```

#### 3. Mantener actualizada

```bash
# Regularmente, sincronizar con develop
git checkout develop
git pull origin develop
git checkout feature/nueva-funcionalidad
git merge develop
```

#### 4. Pull Request / Merge Request

```bash
# Crear PR desde la plataforma (GitHub, GitLab, etc.)
# O hacer merge local si está permitido
git checkout develop
git merge feature/nueva-funcionalidad
git push origin develop
```

#### 5. Limpiar

```bash
# Eliminar rama local
git branch -d feature/nueva-funcionalidad

# Eliminar rama remota
git push origin --delete feature/nueva-funcionalidad
```

### 🚨 Flujo para Hotfixes

#### 1. Crear desde main

```bash
git checkout main
git pull origin main
git checkout -b hotfix/critical-bug-fix
```

#### 2. Corregir y probar

```bash
git add .
git commit -m "fix: corregir error crítico en sistema de pagos"
git push -u origin hotfix/critical-bug-fix
```

#### 3. Merge a main y develop

```bash
# Merge a main
git checkout main
git merge hotfix/critical-bug-fix
git tag -a v1.2.1 -m "Hotfix v1.2.1"
git push origin main --tags

# Merge a develop
git checkout develop
git merge hotfix/critical-bug-fix
git push origin develop
```

#### 4. Limpiar

```bash
git branch -d hotfix/critical-bug-fix
git push origin --delete hotfix/critical-bug-fix
```

## Comandos Esenciales

### Crear y Cambiar Ramas

```bash
# Crear y cambiar a nueva rama
git checkout -b feature/nueva-rama

# Solo cambiar de rama
git checkout feature/rama-existente

# Crear rama desde commit específico
git checkout -b feature/nueva-rama abc1234
```

### Ver Ramas

```bash
# Listar ramas locales
git branch

# Listar todas las ramas (locales y remotas)
git branch -a

# Ver última actividad de cada rama
git branch -v
```

### Sincronizar con Remoto

```bash
# Subir nueva rama
git push -u origin feature/nueva-rama

# Actualizar rama desde remoto
git pull origin feature/rama-actual

# Descargar todas las ramas remotas
git fetch --all
```

### Mergear Ramas

```bash
# Merge simple
git checkout develop
git merge feature/completada

# Merge con mensaje personalizado
git merge feature/completada -m "Merge: integrar nueva funcionalidad"

# Merge sin fast-forward (mantiene historial)
git merge --no-ff feature/completada
```

### Eliminar Ramas

```bash
# Eliminar rama local (solo si está mergeada)
git branch -d feature/completada

# Forzar eliminación local
git branch -D feature/experimental

# Eliminar rama remota
git push origin --delete feature/completada
```

## Mejores Prácticas

### ✅ Hacer

#### 1. **Ramas Pequeñas y Enfocadas**

```bash
# BIEN - Enfocada en una funcionalidad
feature/user-authentication

# MAL - Muy amplia
feature/complete-user-system
```

#### 2. **Actualizar Regularmente**

```bash
# Mantener sincronizada con develop cada día o dos
git checkout feature/mi-rama
git merge develop
```

#### 3. **Tests Antes del Merge**

- Ejecutar todas las pruebas
- Verificar que el build funciona
- Probar la funcionalidad manualmente

#### 4. **Revisión de Código**

- Siempre usar Pull/Merge Requests
- Solicitar review de al menos un compañero
- Revisar los cambios antes de aprobar

#### 5. **Documentar Cambios Complejos**

```bash
# En la descripción del PR
## Cambios incluidos
- Implementa autenticación OAuth
- Agrega middleware de validación
- Actualiza documentación de API

## Cómo probar
1. Configurar variables de entorno
2. Ejecutar `npm test`
3. Probar login en /auth/google
```

### ❌ Evitar

#### 1. **Ramas de Larga Duración**

- No mantener features abiertas por semanas
- Mergear frecuentemente a develop

#### 2. **Commits Directos a Main**

- Nunca hacer push directo a main/master
- Siempre usar Pull Requests

#### 3. **Nombres Genéricos**

```bash
# MAL
feature/fix
feature/update
feature/new-stuff

# BIEN
feature/implement-jwt-auth
bugfix/fix-email-validation
```

#### 4. **Mergear Sin Revisar**

- No hacer merge de tus propios PRs
- Revisar conflicts antes de resolver

## Resolución de Conflictos

### Identificar Conflictos

```bash
# Al hacer merge aparecerá
git merge feature/otra-rama
# Auto-merging file.js
# CONFLICT (content): Merge conflict in file.js
```

### Resolver Conflictos

1. **Abrir archivos con conflictos**

```javascript
// Aparecerá algo como:
<<<<<<< HEAD
const mensaje = "Versión en develop";
=======
const mensaje = "Versión en feature";
>>>>>>> feature/nueva-funcionalidad
```

1. **Editar y resolver**

```javascript
// Decidir qué versión mantener o combinar
const mensaje = "Versión final combinada";
```

1. **Completar merge**

```bash
git add .
git commit -m "resolve: conflict in file.js"
```

### Herramientas para Conflictos

```bash
# Usar herramienta visual
git mergetool

# Ver estado de conflictos
git status

# Abortar merge si es necesario
git merge --abort
```

## Ejemplos Prácticos

### Caso 1: Nueva Funcionalidad Completa

```bash
# 1. Crear rama
git checkout develop
git checkout -b feature/shopping-cart

# 2. Desarrollar en pequeños commits
git commit -m "feat(cart): crear estructura básica"
git commit -m "feat(cart): implementar agregar productos"
git commit -m "feat(cart): calcular totales"
git commit -m "test(cart): agregar pruebas unitarias"

# 3. Merge a develop
git checkout develop
git merge feature/shopping-cart
git branch -d feature/shopping-cart
```

### Caso 2: Bugfix con Issue

```bash
# Issue #456: Error en validación de email
git checkout develop
git checkout -b bugfix/456-email-validation

# Corregir y probar
git commit -m "fix(auth): corregir regex de validación de email

Fixes #456"

# PR y merge
```

### Caso 3: Hotfix de Emergencia

```bash
# Error crítico en producción
git checkout main
git checkout -b hotfix/payment-processor-fix

# Corregir rápidamente
git commit -m "fix(payments): corregir timeout en procesador

Resuelve problema de pagos fallidosz por timeout de 30s.
Aumenta timeout a 60s y agrega retry automático."

# Merge a main
git checkout main
git merge hotfix/payment-processor-fix
git tag v1.5.1

# Merge a develop
git checkout develop
git merge hotfix/payment-processor-fix

# Deploy inmediato
git push origin main --tags
```

### Caso 4: Feature con Colaboración

```bash
# Desarrollador A crea base
git checkout -b feature/user-dashboard
git commit -m "feat(dashboard): estructura inicial"
git push -u origin feature/user-dashboard

# Desarrollador B contribuye
git checkout feature/user-dashboard
git commit -m "feat(dashboard): agregar widgets"
git push origin feature/user-dashboard

# Desarrollador A finaliza
git pull origin feature/user-dashboard
git commit -m "feat(dashboard): integrar datos en tiempo real"
git push origin feature/user-dashboard
```

## Checklist

### ✅ Antes de Crear una Rama

- [ ] Estoy en la rama base correcta (`develop` para features)
- [ ] La rama base está actualizada (`git pull`)
- [ ] El nombre sigue la nomenclatura establecida
- [ ] El alcance de la rama está bien definido

### ✅ Durante el Desarrollo

- [ ] Hago commits pequeños y frecuentes
- [ ] Los mensajes de commit siguen el estándar
- [ ] Sincronizo regularmente con la rama base
- [ ] Las pruebas pasan correctamente

### ✅ Antes del Merge

- [ ] Todos los tests pasan
- [ ] El código ha sido revisado
- [ ] No hay conflicts sin resolver
- [ ] La funcionalidad está completamente terminada
- [ ] La documentación está actualizada

### ✅ Después del Merge

- [ ] La rama ha sido eliminada localmente
- [ ] La rama remota ha sido eliminada
- [ ] El issue/ticket está cerrado
- [ ] Se ha comunicado la integración al equipo

## Configuración Recomendada

### Protección de Ramas

```bash
# En GitHub/GitLab, configurar:
# - Require pull request reviews
# - Require status checks to pass
# - Require up-to-date branches
# - Include administrators
```

### Aliases Útiles

```bash
# Agregar a ~/.gitconfig
[alias]
    co = checkout
    br = branch
    st = status
    new-feature = "!f() { git checkout develop && git pull && git checkout -b feature/$1; }; f"
    finish-feature = "!f() { git checkout develop && git merge $1 && git branch -d $1; }; f"
```

### Templates de PR

Crear archivo `.github/pull_request_template.md`:

```markdown
## Descripción
Breve descripción de los cambios

## Tipo de cambio
- [ ] Bug fix
- [ ] Nueva funcionalidad
- [ ] Cambio disruptivo
- [ ] Documentación

## Checklist
- [ ] Tests agregados/actualizados
- [ ] Documentación actualizada
- [ ] Code review solicitado
```

------

## 📞 Soporte

Para dudas sobre el workflow de ramas o problemas técnicos, contacta al tech lead o crea un issue en el repositorio del equipo.

**Recuerda**: Una buena estrategia de branching es clave para un desarrollo eficiente y sin conflictos. ¡Úsala consistentemente!