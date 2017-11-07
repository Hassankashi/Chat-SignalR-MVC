# Chat-SignalR-MVC
Real Time Web Solution for Chat by MVC SignalR Hub, This repository explains SignalR concept via chat implementation and interaction between client and server visually and involving hub class.

I strongly recommend you to read this article:
https://www.codeproject.com/Articles/732190/Real-Time-Web-Solution-for-Chat-by-MVC-SignalR-H


Nowadays, due to increase in the amount of information and necessity of achieving data in short time, we need technologies to cover our requirement in this issue. Assume when in stock market prices are changing in each moment, do you think that user should refresh page every moment to inform the last price? Obviously, it is not a reasonable solution for such a problem. Or with increase in producing products and services, we need customer service to help user and buyer, the best and cheaper communication is conversation by chat program. By the same token, we cannot force user to press button for receiving our last message.
SignalR is a real time technology which is using the set of asynchrony library to make a persistence connection between client and server. User can receive last update data from server without traditional way such as refresh page or press button.
Background
You need to know MVC 4.0 Technology and EntityFramework > 4.0  to get this article better. I recommend this link: {MVC Tutorial: http://technical.cosmicverse.info/Article/Index/3  } and { Data Access Layer Tutorial: http://technical.cosmicverse.info/Article/Index/4 } to learn step by step about MVC and Entity.
In the other hand SignalR uses the below approaches to establish real time web:
1. WebSocket
Websocket is a full duplex protocol and uses http handshaking internally and allow stream of messages flow on top of TCP. It supports: Google Chrome (> 16) Fire Fox (> 11) IE (> 10) Win IIS (>8.0). Due to encrypt message and full duplex, websocket is the best solution and at first signalR checks both web server and client server whether they support websocket or not.
Simplex Communication
It just spreads in one way when one point just broadcasts while another point just can listen without sending message, such as television and radio.
Half duplex
One point sends message and in this moment another point cannot send message and should wait until the first point finishes its transmission and then send its message, it is just a one communication line at a time, such as old wireless device walkie-talkie and HTTP protocol.


Full duplex
Both points can send and receive message at a time simultaneously, there is no need to wait until other point finishes its transmission such as telephones and websocket protocol.v
2. Server Sent Events (SSE)
The next choice for signalr is server sent event, because of persistence communication between server and client. In this approach, communication does not disconnect and last data from server will update automatically and transmit to client via HTTP connection. EventSource is part of HTML5 technology.

3. Forever Frame
When client sends request to server, then server sends a hidden iframe as chunked block to client so this iframe is responsible to keep connection between client and server forever. Whenever server changes data, then send data as script tag to client (hidden iframe) and these scripts will be received sequentially.

4. Polling
Client sends request to server and server responses immediately but after that, server disconnects connection so again for establishing communication between server and client, we should wait for next request from client. To solve this problem, we have to set timeout manually and for each 10 seconds client sends request to server to check new modification in server side and gets last update data. Polling uses resources and it is not an economic solution.

5. Long Polling
Client sends request to server and server responds immediately and this connection remains until a specific time and during this period clients do not have to send explicit request to server while in polling client has to send explicit request to server during timeout. Comet programming covers this concept.

Briefly SignalR library chooses one type of transmit data between client and server, its priority is websocket, server sent event, long polling and forever iframe. There are two classes inside this library as follows:
1. Persistentconnection
It is low level so it is complex and needs more configuration but in return gives more facility to handle class personally.
2. Hub
It is high level and more popular to use it.

How to implement simple chat scenario by the aid of signalr and hub class?
My aim is just to issue a random scenario for involving signalr. You can use it for your personally scenario and I just follow the below steps to make challenge with server (hub class) and client side and illustrate how client send request and server respond? How they interact with each other?
Scenario Description
I want to establish an application for customer service department. There are some administrations that are responsible to help client and on the other side there are clients who ask question and need help.
Assume two admins are online and connect to chat service and the first client comes to ask a question, so system connects the first client to first free admin and for second client this story will repeat, but third client gives alarm from system that there is no admin to help. Whenever first client disconnects, the first admin becomes free.
My contract for this scenario is to use flag for reminding which user who is connected is user or admin and which one is free or busy. In my database, if admincode is equal to zero so it is user otherwise it is admin, and I define flag “tpflag” (in application) is equal to zero for user and equal to one for admin. Whenever they connect to chat flag “freeflag” becomes zero which shows busy user and as soon as client leaves conversation becomes one which shows free status.
if freeflag==0 ==> Busy
if freeflag==1 ==> Free
if tpflag==0 ==> User
if tpflag==1 ==> Admin
Prerequisites
Visual Studio 2012
SQL server 2008
Install necessary dependency from package manager console
Step 1: Create Project
File --> New Project --> ASP.Net MVC 4 Web Application { Give Name and Directory} --> { Template=Basic & View Engine=Razor }
Step 2: Open PM for Installing Dependency Files
Menu (Tools) --> Library Package Manager --> Package Manager Console

Please read more on:
https://www.codeproject.com/Articles/732190/Real-Time-Web-Solution-for-Chat-by-MVC-SignalR-H
