# GraphicdTools

🎨 *Conversor gráfico avanzado para modding de Winning Eleven 2002 — soporta BMP ↔ TIM, paletas y compresión BIN.*

**GraphicdTools** es una utilidad especializada en la conversión entre formatos gráficos usados en *Winning Eleven 2002* (PC) y formatos estándar editables. Permite a los modders trabajar con herramientas comunes (como GIMP o Photoshop) y luego exportar sus diseños al formato exacto que el juego entiende.

Desarrollado bajo el pseudónimo **CARP**, este programa resuelve uno de los mayores dolores de cabeza del modding retro: **la incompatibilidad entre formatos de imagen y paletas**.

---

## 🔁 Funcionalidades principales

### 🖼️ Conversión de imágenes
- **BMP → TIM** (16 colores / 4bpp y 256 colores / 8bpp)
- **TIM → BMP** (para edición externa)

### 🎨 Gestión de paletas
- Extrae y convierte **paletas de color** desde:
  - BMP indexado (4bpp o 8bpp)
  - Archivos TIM
- Genera paletas compatibles con el motor del juego

### 📦 Compresión/Descompresión
- **TIM → BIN** (comprime múltiples TIMs en un contenedor BIN)
- **BIN → TIM** (extrae todos los gráficos individuales del BIN)

> ✅ Ideal para modificar archivos como `MENU.BIN`, `FLAG.BIN`, `STADIUM.BIN`, etc.

---

## 🛠️ Casos de uso típicos

- Editar un escudo en GIMP (como BMP 256 colores) → convertirlo a TIM → empaquetarlo en un BIN.
- Extraer los gráficos originales del juego para usarlos como base de nuevos diseños.
- Reemplazar menús, íconos o banderas sin romper la estructura del juego.

---

## 💻 Tecnología

- **Lenguaje**: C#  
- **Framework**: .NET (Windows Forms)  
- **Plataforma**: Windows (PC)  
- **Tipo**: Utilidad de escritorio para modding gráfico

---

## ⚠️ Notas importantes

- Los archivos **BMP deben ser indexados** (no RGB). Usa modo "Indexed Color" en GIMP o Photoshop.
- El formato **TIM** usado aquí sigue la especificación de *Winning Eleven 2002* (no el TIM genérico de PlayStation).
- Las dimensiones de las imágenes deben coincidir con las del recurso original (el juego no las redimensiona).

---

## 🧠 Inspiración

> *"No quería adivinar qué color era el #47... quería ver la paleta completa y pintar con precisión."*

Esta herramienta nace de cientos de horas tratando de entender cómo el juego interpreta cada píxel. Hoy, la comparto para que otros puedan crear sin barreras técnicas.

---

## 📜 Licencia

Uso permitido con fines **no comerciales**. Si reutilizás el código o la idea, citá a **Maximiliano Ducoli (CARP)** como autor original.

---

🖌️ ¡Editá, convertí, empaquetá… y hacé que el juego luzca como siempre soñaste!
