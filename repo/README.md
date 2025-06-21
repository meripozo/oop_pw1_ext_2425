# oop_pw1_ext_2425
<img src="repoPictures/Logo_UFV.jpg"
style="width:3.44792in;height:1.48958in" />

> **ESCUELA** **POLITÉCNICA** **SUPERIOR**
>
> **Object-Oriented** **Programming**
>
> **Practical** **Work** **I** **Extraordinary**
>
> María Fernández del Pozo Romero
>
> **Grade:** Computer Engineering, 2 Aº
>
> **Student** **Id:** 43009306433
>
> **June,** **2025.**

**INDEX**

**Introduction..............................................................................................................................3**

**Description of the project.......................................................................................................3** 

**Station.cs Functions.................................................................................................................3**

**Maui Class Diagram.................................................................................................................4**

**Problems....................................................................................................................................4**

**Conclusion.................................................................................................................................5**

**Introduction**

This document will explain in detail the most important and fundamental
aspects of my code development for this project, including a detailed
description of my solution. I will also explain the fundamental problems
I faced during the development of this project and the solutions I
considered. Finally, I will provide a conclusion to the project.

**Description** **of** **the** **project**

In this section, I'll explain in detail the development and operation of
my solution. The program is composed of the following classes:

> \- Train class: This is the abstract class from which both types of
> trains will inherit their attributes, as well as the virtual function
> *ShowTrainsInfo()*, which will be overridden in the child classes.
>
> \- FreightTrain and PassengerTrain classes: These are the child
> classes of train, where the *ShowTrainsInfo()* function is overridden.
>
> \- Program class: In this class, I decided to control the program flow
> using Boolean variables to control the main *Main()* loop.
>
> \- Platform class: This class is subsequently instantiated in Station
> and Program. It has also been used to create a list of platforms in
> Station that stores trains that arrive in the Docking state.
>
> \- Station class: I have used this class as the "controller class,"
> meaning it controls the important flow of the program and is composed
> of the fundamental functions used in the program. In this class, I
> create two lists that I will use throughout the program: a list of
> platforms and a list of trains. In the constructor of this class, I
> have put numberPlatforms, because initially, the user decides how many
> platforms there will be in the station.

**Station.cs** **Functions**

> \- *void* *LoadTrainsFromFile()*: This function is called from
> *Main()*. It asks for the file path and checks if it exists. It then
> executes *File.ReadAllLines* to begin reading the entire file,
> inserting each element of each line into its corresponding position in
> the train list. Exception handling is performed throughout the
> function using try catches.
>
> \- *void* *AdvanceTick()*: This function iterates through the list of
> trains, updating the arrivalTime for those that are still Enroute or
> Waiting. *CheckTrains()* is then called, where the train and platform
> statuses are updated as necessary.
>
> \- *void* *CheckTrains()*: In this function, I begin by clearing the
> platforms where the train has entered the Docked state, to make way
> for the next train. I've decided to Remove the train from the platform
> when it's already Docked (but without deleting the train from the
> train list) so that the next train can be passed if the user doesn't
> enter enough platforms to fill all the platforms with trains and
> prevent a new train from entering a station. I then loop through the
> list of trains for those that are enRoute and Waiting
>
> with arrivalTime set to zero, resetting the trains to Docked and the
> platforms that were Free to Occupied if possible.
>
> \- *void* *StartSimulation()*: This function continuously calls
> *DisplayStatus()* and *AdvanceTick()* to subtract the arrivalTime of
> the trains and change the states of the trains and platforms if
> necessary, finally exiting the loop when all the trains are Docked.
>
> \- *void* *DisplayStatus()*: This function simply calls the
> *ShowPlatformsInfo()* and *ShowTrainsInfo()* functions.

**Maui** **Class** **Diagram**

The class diagram of my project, which includes the relationships
between them, is as follows:

**Problems**

> \- At first, when printing the train and platform lists, I was
> printing duplicates of the platforms and part of the train list.
> Later, I realized I hadn't set *ConsoleClear()* correctly, which was
> why the terminal wasn't clearing.
>
> \- The arrival time kept subtracting and was \<0. This was because I
> hadn't initially taken into account that once the trains enter the
> Docked state and are released from the platform, I shouldn't continue
> subtracting the arrivalTime , but rather reset it to zero.
>
> \- At first, the same train was loading on all platforms: the first
> one in the train list. This happened because I hadn't set the loop
> conditions for the *AdvanceTick()* and *CheckTrains()* functions
> correctly, and the trains were loading onto the platforms in the same
> order they were in the train list.
>
> \- I should note that I had trouble organizing the order of the for
> and foreach loops, so sometimes the status change wasn't made or the
> trains weren't printed correctly.
>
> \- Finally, the problem that took me the longest to resolve was that
> in *AdvanceTick()*, I was making changes for only one train each time
> the loop was executed, instead of for the entire train list at once.
> Because of this, the same train was always loading on the platforms.

**Conclusion**

Completing this project has been particularly enriching for me, as it
has allowed us to acquire a deeper understanding of the application of
concepts learned in the Object-Oriented Programming course. I believe
this experience will be very useful for my future career, as I consider
proper command of the C# language in Object-Oriented Programming to be a
fundamental skill in many IT-related career fields.

In conclusion, this project has not only allowed me to consolidate
theoretical concepts but also to confront numerous errors in my code,
which have helped me learn to find alternative ways to implement the same code. 
Therefore, I believe this project has been helpful and will also provide a solid 
foundation for other courses that require programming knowledge throughout my degree.

