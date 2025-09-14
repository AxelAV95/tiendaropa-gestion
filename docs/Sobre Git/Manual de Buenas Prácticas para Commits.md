# Manual de Buenas Prácticas para Commits

## 📋 Índice

1. [Introducción](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#introducción)
2. [Estructura Básica de un Commit](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#estructura-básica-de-un-commit)
3. [Tipos de Commits](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#tipos-de-commits)
4. [Nomenclatura y Formato](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#nomenclatura-y-formato)
5. [Ejemplos Prácticos](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#ejemplos-prácticos)
6. [Qué NO Hacer](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#qué-no-hacer)
7. [Comandos Útiles](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#comandos-útiles)
8. [Checklist de Verificación](https://claude.ai/chat/f5b46418-636c-41bb-b595-e51fb9d8e4cb#checklist-de-verificación)

## Introducción

Este manual establece las reglas y buenas prácticas para realizar commits de manera consistente y profesional. Un buen historial de commits facilita el mantenimiento del código, la colaboración en equipo y la resolución de problemas.

### ¿Por qué es importante?

- **Claridad**: Otros desarrolladores entienden rápidamente qué cambios se hicieron
- **Historial limpio**: Facilita el seguimiento de cambios y la depuración
- **Colaboración**: Mejora la comunicación entre el equipo
- **Automatización**: Permite generar changelogs automáticamente

## Estructura Básica de un Commit

```
<tipo>(<alcance>): <descripción>

<cuerpo opcional>

<footer opcional>
```

### Componentes:

- **Tipo**: Categoría del cambio (obligatorio)
- **Alcance**: Módulo o área afectada (opcional)
- **Descripción**: Resumen breve del cambio (obligatorio)
- **Cuerpo**: Explicación detallada (opcional)
- **Footer**: Información adicional como issues cerrados (opcional)

## Tipos de Commits

### 🆕 feat (Feature)

**Uso**: Nueva funcionalidad para el usuario

```
feat(auth): agregar login con Google OAuth
feat: implementar sistema de notificaciones push
```

### 🐛 fix (Fix)

**Uso**: Corrección de errores

```
fix(api): corregir error 500 en endpoint de usuarios
fix: solucionar problema de memoria en carga de imágenes
```

### 📚 docs (Documentation)

**Uso**: Cambios en documentación

```
docs: actualizar README con instrucciones de instalación
docs(api): agregar ejemplos de uso en documentación
```

### 💎 style (Style)

**Uso**: Cambios de formato que no afectan la funcionalidad

```
style: corregir indentación en archivo de configuración
style(css): normalizar espaciado en hojas de estilo
```

### ♻️ refactor (Refactor)

**Uso**: Cambios de código que no agregan funcionalidad ni corrigen errores

```
refactor(utils): simplificar función de validación de email
refactor: extraer lógica común a clase utilitaria
```

### ⚡ perf (Performance)

**Uso**: Mejoras de rendimiento

```
perf(db): optimizar consulta de usuarios activos
perf: implementar lazy loading en componentes
```

### 🧪 test (Test)

**Uso**: Agregar o modificar pruebas

```
test(auth): agregar pruebas unitarias para login
test: implementar pruebas de integración para API
```

### 🔧 chore (Chore)

**Uso**: Tareas de mantenimiento, configuración, dependencias

```
chore: actualizar dependencias de desarrollo
chore(build): configurar webpack para producción
```

### 🚀 build (Build)

**Uso**: Cambios en sistema de build o dependencias externas

```
build: actualizar Node.js a versión 18
build(docker): optimizar imagen de contenedor
```

### 🔁 ci (Continuous Integration)

**Uso**: Cambios en archivos de CI/CD

```
ci: agregar workflow de GitHub Actions
ci(jenkins): configurar pipeline de deployment
```

## Nomenclatura y Formato

### Reglas Generales

1. **Idioma**: Usar español de forma consistente
2. **Tiempo verbal**: Usar infinitivo (agregar, corregir, implementar)
3. **Longitud**: Máximo 50 caracteres en la descripción
4. **Mayúsculas**: Solo la primera letra en mayúscula
5. **Punto final**: No usar punto al final de la descripción

### Formato del Alcance

- Usar nombres cortos y descriptivos
- Ejemplos: `auth`, `api`, `ui`, `db`, `config`
- Opcional pero recomendado para proyectos grandes

### Descripción Efectiva

```
✅ CORRECTO
feat(auth): implementar reseteo de contraseña
fix(api): corregir validación de datos de entrada
docs: actualizar guía de instalación

❌ INCORRECTO
feat: cosas nuevas
fix: arreglé un bug
update: cambios varios
```

## Ejemplos Prácticos

### Ejemplos de Commits Completos

```bash
# Feature nueva
feat(payment): integrar pasarela de pago con Stripe

Implementa el sistema completo de pagos incluyendo:
- Creación de sesiones de checkout
- Webhook para confirmación de pago
- Manejo de errores y reembolsos

Closes #123
# Corrección de error crítico
fix(security): corregir vulnerabilidad XSS en formularios

Sanitiza todas las entradas de usuario antes de renderizar
en el DOM para prevenir ataques de cross-site scripting.

Fixes #456
Reviewed-by: @security-team
# Refactoring
refactor(database): migrar de MySQL a PostgreSQL

Actualiza todos los modelos y consultas para ser compatibles
con PostgreSQL manteniendo la funcionalidad existente.
```

### Commits Simples

```bash
feat: agregar modo oscuro
fix: corregir error en cálculo de totales
docs: actualizar changelog
test: agregar pruebas para módulo de reportes
chore: actualizar dependencias de seguridad
```

## Qué NO Hacer

### ❌ Commits Muy Grandes

```bash
# MAL
feat: implementar todo el módulo de usuarios con auth, perfiles, configuración, notificaciones y reportes
```

### ❌ Mensajes Poco Descriptivos

```bash
# MAL
fix: bug
update: stuff
chore: things
feat: new feature
```

### ❌ Mezclar Tipos de Cambios

```bash
# MAL
feat: agregar login y corregir error en logout y actualizar documentación
```

### ❌ Commits de "Work in Progress"

```bash
# MAL
wip: working on feature
temp: temporary changes
save: saving progress
```

## Comandos Útiles

### Hacer un Commit Básico

```bash
git add .
git commit -m "feat(auth): implementar login con JWT"
```

### Commit con Cuerpo Detallado

```bash
git commit -m "feat(auth): implementar login con JWT" -m "Agrega autenticación segura con tokens JWT incluyendo refresh tokens y middleware de validación"
```

### Modificar el Último Commit

```bash
# Cambiar mensaje del último commit
git commit --amend -m "nuevo mensaje"

# Agregar archivos al último commit
git add archivo_olvidado.js
git commit --amend --no-edit
```

### Ver Historial de Commits

```bash
# Formato compacto
git log --oneline

# Con información del autor
git log --pretty=format:"%h - %an, %ar : %s"
```

## Checklist de Verificación

Antes de hacer commit, verifica:

### ✅ Pre-Commit

- [ ] Los cambios están relacionados y son coherentes
- [ ] El código compila sin errores
- [ ] Las pruebas pasan correctamente
- [ ] No hay archivos temporales o de configuración personal
- [ ] El mensaje sigue la nomenclatura establecida

### ✅ Mensaje del Commit

- [ ] Tiene el tipo correcto (`feat`, `fix`, `docs`, etc.)
- [ ] La descripción es clara y concisa (máximo 50 caracteres)
- [ ] Usa infinitivo en español
- [ ] No termina en punto
- [ ] El alcance es apropiado (si se usa)

### ✅ Contenido del Commit

- [ ] Incluye solo cambios relacionados
- [ ] No mezcla diferentes tipos de modificaciones (a menos que estén interrelacionados)
- [ ] Los archivos agregados son necesarios
- [ ] Se removieron archivos obsoletos
- [ ] Si es un commit mixto, está justificado y documentado

## Configuración Recomendada

### Template de Commit

Crear archivo `.gitmessage` en el proyecto:

```
<tipo>(<alcance>): <descripción>

# Explicación detallada del cambio (opcional)
#
# Incluir motivación y contexto del cambio
# 
# Closes #<número_issue>
```

### Usar el Template

```bash
git config commit.template .gitmessage
```

### Hook de Pre-Commit

Crear archivo `.git/hooks/pre-commit` para validar formato automáticamente.

## Herramientas Recomendadas

### Commitizen

Ayuda a crear commits con formato consistente:

```bash
npm install -g commitizen
npm install -g cz-conventional-changelog
```

### Conventional Changelog

Genera changelogs automáticamente:

```bash
npm install -g conventional-changelog-cli
```

------

