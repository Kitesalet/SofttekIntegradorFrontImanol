# Trabajo Integrador Academia Softtek TechOil - FrontEnd 🌠


![TechOil Logo](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/fe19a6e6-aaa1-4dcf-8190-5f1cb8fceba3)

(Prestar atención al slogan 😉 )

## Descripción

Un trabajo integrador de la academia de softtek de .NET en progreso, basandose en ciertos requerimientos
especificos para la conformación del mismo. 

Esta basado en la conformación de una WEB API en .Net 6, mediante la utilización del ORM Entity
Framework, siendo code first la metodología a utilizar para crear las base de datos, y mediante el uso de DataAnnotations para
el setteo de las propiedades de cada campo en las entidades, asi como la utilización de Fluent Api para el seedeo de la data al realizar migrations
a la base de datos, y JWT para la autorización y autenticación de la mayoría de los endpoints de la misma.

Esta basado en el consumo de la aplicación WEB API en .Net 6 creada para lo que sería la parte del backend del mismo, junto con consumir los datos
de la base de datos creada con anterioridad, en base a tomar requests y plasmarla en un frontend amigable y responsivo, que va a intentar 
consumir todos los endpoints creados por la API en si.

La aplicacion web se basa en el diseño y desarrollo de un sistema de gestión para una empresa
ficticia denominada TechOil, líder en el sector Oil & Gas en latinoamerica, para lograr un correcto ABM de nuevos usuarios con roles especificos, junto con el login
de los mismos, y un ABM para tablas de Servicios, Proyectos, Roles y Trabajos.



## **Arquitecture Specifications**
​
### **Controller Layer**
Es el punto de entrada a la API. Tenemos 5 controllers en la aplicación, uno por cada entidad de la misma ( User,Service,Project y Work ), asi como
también un controller que será utilizado para realizar los logins en la aplicación, dandonos un token que hará de sesión de usuario para que se puedan
utilizar los enpoints en los demas controllers.


![image](https://github.com/Kitesalet/SofttekIntegradorFrontImanol/assets/104630744/416ecf73-0283-4da5-bd1a-793e1202c9c1)

​
### **Views Layer**
Es la capa donde tendremos las vistas del programa, que son las que se encargan de asociar archivos .js junto con su funcionalidad a la página,
asi como también, y mas importantemente, se encargan de darle la cara y visibilidad a la página con sus componentes HTML y CSS integrados.
En este caso, todo el proyecto se encuentra estilizado mediante la utilización de la biblioteca CSS / JS bootstrap.

![image](https://github.com/Kitesalet/SofttekIntegradorFrontImanol/assets/104630744/81a255eb-75cb-4db3-8306-1603ebba45dc)


​
### **Model Layer**
En este nivel de la arquitectura se definen todas las entidades de la base de datos, asi como también vamos a definir todas las interfases,
y clases comunes que se utilizan en la totalidad de la aplicación. En esta capa también se detallan la lista de los DTOs utilizados por cada entidad
y/o endpoint en los controllers y services, enumeradores, diccionarios, asi como también clases que estan asociadas a la capa Helpers.

![image](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/73e7f27e-9c1a-4a0b-8b9b-917177f5bdd0)
​

### **Data Layer**
Es el nivel en el cual tenemos básicamente la clase con la cual nos conectamos directamente a nuestra API, especificamente hablando, a sus endpoints,
mediante esa misma clase nombrada anteriormente llamada BaseApi, que se encargará de llevar los JSON especificos provenientes de la utilizacion y los
inputs del usuario en este frontend hacia la misma API.
También es el estrato en el cual tenemos a los DTOs y ViewModels utilizados en las views, para lograr una correcta proyección de los datos que queremos
mostrar y recibir mediante inputs en las views.

![image](https://github.com/Kitesalet/SofttekIntegradorFrontImanol/assets/104630744/15bfc2e3-74f4-4c7e-bda2-b4b8ab8f1b6e)


### Executing program


Para poder lograr la correcta utilización de la aplicación , se tendrá que obtener el Token del request del siguiente endpoint, 
como muestra a continuación, con las credenciales de usuario que se pueden ver en la próxima imagen, siendo este usuario el SuperUser ( Administrador ):

![image](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/28c5010a-1fa6-41ec-8f5b-0b13276b6f48)

codUsuario:1
password:random



## Help

Ante cualquier consulta o problema, comunicarse via email conmigo a : kitesalett@gmail.com

## Authors

Imanol Echazarreta

## Version History

* 1.0
  * Release date: 2/10/2023


