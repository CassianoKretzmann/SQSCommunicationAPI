# SQSCommunicationAPI

## Web API using ASPNet Core to communicate with AWS Simple Queue Service.

### Possible actions:
#### Send messages to a queue in AWS Simple Queue Service.
#### Receive messages with a background processor and delete after read them succesfully.

### Requirements:
#### Have a AWS account.
#### Create a queue.
#### Create a user with permissions in this queue.

### Configuration in the class EnvironmentData:
#### Change the QUEUE_URL with the url from the queue you created.
#### Change the ACCESS_KEY with the access key from the user created.
#### Change the SECRET_KEY with the secret key from the user created.

