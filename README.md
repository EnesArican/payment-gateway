# Payment Gateway Api


## How To Run

**Prerequisites** </br>
To run the application, you will need to have [docker](https://docs.docker.com/get-docker/) installed on your machine along with [docker compose](https://docs.docker.com/compose/install/).
</br>

**Build and run the application** </br>
Open a command prompt and navigate to the project folder. Start up the application by running the `docker-compose up` command.
```shell
$ docker-compose up
```
Compose will build the image and run the application.

The app should now be running on http://localhost:8080. 

**Endpoints**</br>
Information on the endpoints can be found on
http://localhost:8080/swagger.

**Cko Bank Simulator**</br>
The bank simulator has been built using [json-server](https://github.com/typicode/json-server), which mocks a backend REST API server.

**Stop the application** </br>
To stop the application, you can either run `docker-compose down` from within the project directory in another terminal, or by hitting CTRL+C in the original terminal where the app was started.

## Assumptions

The following assumptions have been made in the project:

- Authorization of user is not required to send a payment.
- User sending a payment will provide a currency code together with a `amount` value in the provided currency, and with the correct number of decimals for that currency.
- User sending a payment will send a valid cvv number.
- The payment status can only be set to one of the following three statuses: 
  - Pending
  - Paid
  - Declined

## Areas for improvement

At present, when attempting a payment request, there is partial validation of the data provided by the user . This could be further improved with additional validation on other properties that are sent with the request. 

More unit tests could be added to ensure that the client, controller and service classes are behaving as expected as well as unit testing the validation and masking methods.

Ideally the app should also be configured to enforce a HTTPS connection

## Cloud Technologies

The payment gateway app could be hosted on an Amazon Elastic Compute Cloud (EC2) instance. With utilization of a virtual computing environment, This tool provides many benefits such as: 

 - Custom configuration of CPU, memory, storage, and networking capacity.
 - Scalability that ensures the app is responsive to changing capacity requirements.
 - Integration and security with other AWS tools such as Amazon Virtual Private Cloud (VPC).


