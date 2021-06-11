# mercadolibre.test
Prueba técnica para ingreso a mercado libre

Hola! les contaré un poco sobre lo que hice para esta prueba:

Antes que nada compartir mi comprensión del reto 
-Hacer una app para consultar productos desde las API de Mercado libre
-Debe contener 3 pantallas, la primera para buscar productos por cualquier criterio, la segunda para mostrar los resultados de la búsqueda y la tercera para mostrar más detalles de un producto seleccionado,
la api devolvía muchos campos y como no estaba especificada la información que se debía mostrar, no los utilicé todos

ahora si, qué se hizo

1. creé un proyecto en Xamarin Classic Android, aunque llevaba más de un año sin trabajar con android en Xamarin, pude sacar un buen resultado
2. creé dos capas para el manejo de la información, una logic y otra droid, (si hay un reto para realizar la app en iOS se puede reutilizar el código de logic)
3. utilicé clientHttp para consumir el servicio
4. utilicé Autofac para localizar las interfaces y evitar constantes instancias
5. utilicé un patron MVP para trabajar con la respuesta del servicio asincrona y de una manera más limpia, de tal manera que el presentador sirva como puente entre los proyectos Android y iOS con el consumo de servicios
6. implementé unos layouts básicos para maquetar las pantallas.

--------------------//////////---------------------

para usar la app simplemente deben instalar el artefacto .apk o correr el proyecto desde visual studio sobre un dispositivo físico o emulador,
inicialmente tendrá un campo de texto y un botón para realizar la búsqueda 
si el campo no tiene ningun texto la búsqueda no se realizará

al escribir algo en el campo se habilitará el botón y se mostrará un spinner mientras se realiza la consulta al servicio
al obtener los resultados, te llevará a otra pantalla donde se verá una lista de productos relacionados con el criterio de búsqueda, se podrá observar una imagen, el título de producto, precio y ubicación, también un botón que dice: VER DETALLE

al darle click al botón te llevará a otra pantalla que muestra la cantidad de productos vendidos, el estado del producto, la compra a crédito y demás información.

las dos últimas pantallas tienen un botón de volver a la anterior en la parte superior izquierda.

Espero sea de su total agrado y haya una luz de esperanza para trabajar con ustedes =D

Saludos.. Didier Vera!