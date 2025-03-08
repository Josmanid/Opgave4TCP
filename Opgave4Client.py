from socket import *

serverName = "localhost" # Server running on our own computer
serverPort = 7
#we can se what the server sends through this
clientSocket = socket(AF_INET, SOCK_STREAM)
clientSocket.connect((serverName, serverPort))

#This starts an infinite loop so that the client can keep sending messages to the server.
while True:
    message = input("You: ")  # similar to Console.ReadLine();
  

    clientSocket.sendall((message + "\n").encode())  # Send message to server like NetworkStream.Write()
    response = clientSocket.recv(1024).decode()  # Receive server response
    print("Server:", response) # print the response so that i can see it in terminal

clientSocket.close()
