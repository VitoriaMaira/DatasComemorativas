# 🎉 CRUD de Datas Comemorativas  

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-2C7A7B?style=for-the-badge)
![MySQL](https://img.shields.io/badge/MySQL-8.0-4479A1?style=for-the-badge&logo=mysql&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Ativo-success?style=for-the-badge)

---

<div align="center">

## 🚀 Sobre o Projeto

CRUD de **Datas Comemorativas** feito em **.NET 9**, seguindo arquitetura **DDD**, usando **Entity Framework Core** e **MySQL**.  
Organizado, escalável e com tratamento de erros centralizado.

</div>

---

## 🖼️ Demonstração

<img width="1346" height="489" alt="DataComemorativa" src="https://github.com/user-attachments/assets/cc4f27b5-0077-4dd2-ab4e-5a0125168c9a" />


---

## ✨ Funcionalidades

- 🎯 Criar, listar, atualizar e excluir datas comemorativas  
- 🛡️ Tratamento de erros centralizado  
- ⚙️ Arquitetura modular para fácil manutenção  
- 📦 Uso de DTOs e Repositórios seguindo DDD  

---

## 🏗️ Arquitetura

- **API** → Controllers e endpoints REST  
- **Application** → Use Cases  
- **Communication** → Requests e Responses (DTOs)  
- **Domain** → Entidades e regras de negócio  
- **Exception** → Filtros globais e exceções customizadas  
- **Infrastructure** → Repositórios, mapeamentos e integração com MySQL  

---

## 🛠️ Tecnologias Utilizadas

<div align="center">
<img src="https://img.shields.io/badge/.NET-9.0-512BD4?style=flat&logo=dotnet&logoColor=white"/>
<img src="https://img.shields.io/badge/EF%20Core-7.0-2C7A7B?style=flat"/>
<img src="https://img.shields.io/badge/MySQL-8.0-4479A1?style=flat&logo=mysql&logoColor=white"/>
<img src="https://img.shields.io/badge/FluentValidation-✔️-orange?style=flat"/>
<img src="https://img.shields.io/badge/DI-Nativo-4B9CE2?style=flat"/>
</div>

---

## ⚙️ Como Rodar

1. Clone o repositório  

``git clone https://github.com/VitoriaMaira/DatasComemorativas.git``  

2. Configure a string de conexão no appsettings.json:

``{
  "ConnectionStrings": {
    "Connection": "Server=localhost;Database=data_comemorativa;Uid=seu_uid;Pwd=sua_pwd;"
  }
}``

---

## 📬 Endpoints Principais


| Método | Endpoint                  | Descrição                  |
|--------|---------------------------|---------------------------|
| POST   | /datacomemorativa         | Criar uma nova data       |
| GET    | /datacomemorativa         | Listar todas as datas     |
| PUT    | /datacomemorativa/{id}    | Atualizar uma data        |
| DELETE | /datacomemorativa/{id}    | Excluir uma data          |


---


## 📄 Licença

MIT – sinta-se livre para usar, estudar e contribuir.  

---

<div align="center">
👨‍💻 Desenvolvido por Maíra Ribeiro (https://github.com/VitoriaMaira) | ⭐ Deixe uma estrela se este projeto te ajudou!
</div>
