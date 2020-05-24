### Proyecto Idioma
El proyecto permite gestionar el idioma para todo el proyecto que lo invoca recibiendo el id del idioma a utilizar.

Para agregar un nuevo idioma hay que crear el archivo de recurso con las traducciones y agregar el idioma con su ID al archivo de configuracion.

### Proyecto Figura
Identifica la figura y resuelve las ecuaciones seteadas en el momento de la creacion del objeto.

Implementa una base de datos con una tabla de Figuras, en la cual las primeras dos columnas son identificatorias (ID y Nombre) y a partir de la tercera en adelante se setean las ecuaciones. 

Permite agregar nuevas figuras y nuevas ecuaciones al reporte (por ej el volumen de un cubo formado por los lados de un cuadrado). 

Permite trabajar con figuras cuyos lados no son iguales, recibiendo un diccionario de variable:valor que luego es reemplazado en la funcion para realizar el calculo.

Para crear una nueva figura o agregar una ecuacion hay que realizar la modificacion correspondiente a la tabla y agregar las traducciones de la nueva figura o la nueva ecuacion a los archivos de recurso en el proyecto de Idioma.