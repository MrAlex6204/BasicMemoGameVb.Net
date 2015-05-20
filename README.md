# BasicMemoGameVb.Net
Juego de memo echo en vb.net que escribi solo como ejemplo y para uso didactico

En el form hay 20 botones y un control que se llama ImageList
el cual este ImageList contiene un array de imagenes (10 imagenes para ser exactos)

A cada boton tiene y se le asigno propiedad ImageList (el que mencionamos)
Cada boton tiene la propiedad ImageIndex el cual se indica el numero del index de la imagen que sele quiere asignar al boton.

Todos los botones agregados tienen este ImageIndex = -1 por default para que no asigne ninguna imagen de la lista.

Al darle play este obtendra un nuemero del 0-9 y le asignara este numero ala propiedad Tag de cada boton
para guardar que numero que sele asigno aleatoriamente, pero cuidando que no se repita el numero,

Cada numero asignado aleatoriamente es guardado en una lista para verificar que no se repitan.

Sele asigna un numero aleatorio solo ala mitad de los botones
ala otra mitad sele asigna de igual forma 0-9 aleatoriamente pero cuidando que no se repita la numeracion
y que no haiga repetidos.


A cada boton sele asigna el evento click de una manera dinamica(ver comentarios del codigo).

Verificamos si el boton al que seledio click no es el mismo que esta presionado,
  si no lo es, entonces contamos los clicks.
Si es el primer click entonces
 cambiamos el estilo del boton (para dar la apariencia de que esta presionado),
 Luego al boton le asignamos el ImageIndex (Numero de la imagen de la lista 0-9) para que el boton
 tenga una imagen(para que de la impresion que se destapo la imagen oculta) el numero asignado biene en la
 propiedad Tag del boton presionado el mismo numero que se le asigno aleatoriamente.
 y guardamos el boton que dio click en una variable tipo object.

cuando vuelva a dar click verificamos 
Si el conteo de clicks es = 2 entonces
 cambiamos el estado del boton (para que de la impresion de que esta presionado)  
 Luego al boton le asignamos el ImageIndex (Numero de la imagen de la lista 0-9) para que el boton
 tenga una imagen(para que de la impresion que se destapo la imagen oculta) el numero asignado biene en la
 propiedad Tag del boton presionado el mismo numero que se le asigno aleatoriamente.
 y luego guardamos el objeto del boton en una variable tipo object.
 
 Luego verificamos si el boton que presiono primero tiene el mismo numero (El asignado aleatoriamente)
 que el boton 2 presionado si ambos son iguales quiere decir que tienen la misma imagen.
