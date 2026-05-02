# 🎯 Auction Microservice / Microservicio de Subastas

> Microservice developed with a PostgreSQL database, deployed in a Docker container. It follows ONION architecture, using the repository pattern along with a generic repository for data access. AutoMapper is integrated for mapping between entities and DTOs, and the functionalities are exposed through RESTful APIs.  
>  
> The main purpose of this microservice is to create, update, delete, and display auctions, efficiently managing their lifecycle.

---

> Microservicio desarrollado con base de datos **PostgreSQL**, desplegado en un contenedor **Docker**. Implementa una arquitectura **ONION**, utilizando el patrón repositorio junto a un **repositorio genérico** para el acceso a datos.  
>  
> Se integró **AutoMapper** para la conversión entre entidades y DTOs, y las funcionalidades se exponen a través de **APIs RESTful**.  
>  
> La función principal de este microservicio es **crear, actualizar, eliminar e ilustrar subastas**, gestionando eficientemente su ciclo de vida.

---

## 🧱 Tech Stack / Tecnologías Usadas

- ✅ **.NET 6 / .NET 7** – ASP.NET Core Web API
- 🧅 **ONION Architecture**
- 🗂 **Repository Pattern** + **Generic Repository**
- 🐘 **PostgreSQL** – Relational Database
- 🐳 **Docker** – Containerized Deployment
- 🔁 **AutoMapper** – Mapping Entities ⇄ DTOs
- 📡 **RESTful API** – Exposed endpoints for auction management

---

## 📂 Project Structure / Estructura del Proyecto

/AuctionMicroservice
│
├── Application # Reglas de negocio, DTOs, lógica de servicio
├── Domain # Entidades, interfaces, modelos del dominio
├── Infrastructure # Acceso a datos y configuración de PostgreSQL
├── API # Controladores RESTful y configuración general
└── Docker # Dockerfile y docker-compose
