### Overview 

This microservice is designed to manage and process users' gold purchase requests regularly. Users can select a specific day and set it as the designated day of each month. The microservice, upon reaching this date, processes the gold purchase requests of users for the specified amount, and executes the relevant transactions.

### Technologies and Architectures

- Docker: An open-source platform used for running applications in virtual environments.
- .NET Core: Lightweight, fast, and cross-platform framework.
- PostgreSQL: An open-source and powerful relational database management system.
- RabbitMQ: Middleware used for message queues and event-based communication.
- CQRS: An architectural approach that separates command and query responsibilities.

### Usage
This is the view of the microservice from above
![1](https://github.com/dev-fatih-erol/Buying/assets/50841052/5132b8ce-94ec-4685-b634-30de405edd49)

#### The 5 main tasks of microservice are:

- Create instruction<br />
  &nbsp;&nbsp;&nbsp;post /instructions
- Cancel instruction<br />
  &nbsp;&nbsp;&nbsp;put /instructions/cancel
- Get active instruction<br />
  &nbsp;&nbsp;&nbsp;get /instructions/active
- Filter and list canceled instructions<br />
  &nbsp;&nbsp;&nbsp;get /instructions/cancelled
- List notification channels for an instruction<br />
  &nbsp;&nbsp;&nbsp;get /instructions/instructioId/channels

#### The instruction creation process includes the following elements

When creating instructions, the user selects the amount to be received, the instruction day, and the notification channels. Instruction are also sent to RabbitMQ as a **Delayed message** while being added to the database.
