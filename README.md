### Overview 

This microservice is designed to manage and process users' gold purchase requests regularly. Users can select a specific day and set it as the designated day of each month. The microservice, upon reaching this date, processes the gold purchase requests of users for the specified amount, and executes the relevant transactions.

### Technologies and Architectures

- Docker: An open-source platform used for running applications in virtual environments.
- .NET Core: Lightweight, fast, and cross-platform framework.
- PostgreSQL: An open-source and powerful relational database management system.
- RabbitMQ: Middleware used for message queues and event-based communication.
- CQRS: An architectural approach that separates command and query responsibilities.
