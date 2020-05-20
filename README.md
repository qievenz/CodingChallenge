
# InvertirOnline.com Coding Challenge

Bienvenido!

Nos encontramos en la búsqueda de desarrolladores .NET para que se incorporen a nuestro equipo. Después de múltiples procesos de selección, llegamos a la conclusión de que el código habla por si mismo. Con lo cual si te sentís dispuesto a afrontar el desafío, por favor tomate un rato para jugar con el problema y resolverlo.

### Cómo participar del proceso?

Abajo detallamos el problema a resolver, cuando consideres que está resuelto, **no** envíes pull request. Enviá un mail a busquedas.it@invertironline.com con tu resolución (con un link de descarga al repositorio de tu preferencia), y si tenés algún comentario sobre tu implementación, también podés agregarlo ahí.

### El problema

Tenemos un método que genera un reporte en base a una colección de formas geométricas, procesando algunos datos para presentar información extra. La firma del método es:

```csharp
public static string Imprimir(List<FormaGeometrica> formas, int idioma)
```

Al mismo tiempo, encontramos muy díficil el poder agregar o bien una nueva forma geométrica, o imprimir el reporte en otro idioma. Nos gustaría poder dar soporte para que el usuario pueda agregar otros tipos de formas u obtener el reporte en otros idiomas, pero extender la funcionalidad del código es muy doloroso. ¿Nos podrías dar una mano a refactorear la clase FormaGeometrica? Dentro del código encontrarás un TODO con nuevos requerimientos a satisfacer una vez completada la refactorización.

Acompañando al proyecto encontrarás una serie de tests unitarios (librería NUnit) que describen el comportamiento del método Imprimir. **Se puede modificar cualquier cosa del código y de los tests, con la única condición que los tests deben pasar correctamente al entregar la solución.** 

Se agradece también la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada.

### Cómo funciona

Lo que te encontrás al levantar la .sln es una librería con el objeto de negocio FormaGeometrica, y un pequeño proyecto con test unitarios sobre el método de impresión de reporte.

La resolución es libre y cómo encarar el problema queda en el criterio de quien lo resuelva!

**¡¡Buena suerte!!**
