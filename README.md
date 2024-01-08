# Kubernetes with Minikube and .NET Example

### What is Kubernetes?

Kubernetes, often abbreviated as K8s, is an open-source platform designed to automate deploying, scaling, and operating application containers. It groups containers that make up an application into logical units for easy management and discovery.

### Minikube: Your Local Kubernetes

Minikube is a tool that makes it easy to run Kubernetes locally. It runs a single-node Kubernetes cluster on your personal computer (including Windows, macOS, and Linux PCs) so that you can try out Kubernetes, or for daily development work.

## Getting Started with Minikube

1. **Install Minikube**: Follow the instructions on the [official Minikube GitHub page](https://github.com/kubernetes/minikube) to install Minikube on your system.

2. **Start Minikube**: Once installed, start Minikube with the command:
   ```
   minikube start
   ```
   This command creates and configures a virtual machine that runs a single-node Kubernetes cluster.

3. **Verify Installation**: Check that Minikube is properly set up using:
   ```
   minikube status
   ```

4. **Access Kubernetes Dashboard**: To access the Kubernetes Dashboard, a web-based Kubernetes user interface, run:
   ```
   minikube dashboard
   ```

## Deploying a .NET Application on Kubernetes using Minikube

In this repository, you'll find an example .NET application that is ready to be deployed on Kubernetes using Minikube. Here's how to do it:

1. **Clone the Repository**: Clone this repository to your local machine.

2. **Navigate to the Application Directory**: Change your directory to where the .NET application and Kubernetes configuration files are located.

3. **Build the .NET Application**: Use the .NET CLI to build the application. Ensure you have .NET SDK installed on your machine.

4. **Create a Docker Image**: Build a Docker image for the application. Minikube has a built-in Docker environment which can be used:
   ```
   eval $(minikube docker-env)
   docker build -t dotnet-app:latest .
   ```

5. **Deploy to Kubernetes**: Apply the Kubernetes configuration files:
   ```
   kubectl apply -f deployment.yaml
   ```

6. **Access the Application**: Once deployed, access the application via the Minikube service URL:
   ```
   minikube service dotnet-app-service
   ```
