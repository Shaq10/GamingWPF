# GamingWPF
Repo for the gaming WPF which I'm creating for my individual project

# Entity Relationship Diagram
................................

# Class Diagram
![image](https://github.com/Shaq10/GamingWPF/blob/main/classdiagram.png)

## Project Goal
The goal of this project is to create a WPF application which provides a game 
purchasing service for customers. Customers can view games available on a number 
of consoles and choose which to purchase. The project will include all the documentation 
required to show the process of what was done, how and why

# Sprints
![image](https://github.com/Shaq10/GamingWPF/blob/main/PreSprints.png)

## Sprint 1 - 01/12/2020
![image](https://github.com/Shaq10/GamingWPF/blob/main/Sprint1.png)
### Sprint Goal
- [x] Build Database
- [ ] Create business layer
- [ ] Build initial GUI
- [ ] Make a Create Game method
- [x] Update README file
- [x] Commit changes to Github
- [ ] Complete Review
- [ ] Complete Retrospective

### Sprint Review
I completed the database with the 5 tables which I intended to create. Each table uses unique table names, foreign keys are referenced, correct data types are used etc.
I managed to nearly finish the business layer for User Story 0.2 however this was incomplete so I will complete it in Sprint 2. The GUI file was created and referenced to the business layer however it was not implemented and currently displays nothing, so this too will be set for Sprint 2.

### Sprint Retrospective
I overestimated how much work I'd be able to get done within the class time. However, our time was cut a little bit short due to having a Data test in the morning. I may also meet the criteria of my User Stories faster if I focus on one at a time rather than trying to do bits of each one simultaneously. There was also an error relating to absence of .dll files which took over an hour to resolve so this also slowed me down

## Sprint 2 02/12/2020
![image](https://github.com/Shaq10/GamingWPF/blob/main/Sprint2.png)
### Sprint Goal
- [x] Create business layer
- [x] Build initial GUI
- [x] Create Customer in business
- [ ] Create Customer in GUI
- [x] Retrieve all Games
- [x] View all Games

### Sprint Review
I was happy with this sprint. I prioritised the user stories which I was unable to complete during Sprint 1 and complete these. In the process I also comleted some other user stories.
The creating a Customer in GUI user story will be moved to the next sprint as it will be achievable in this one. I also had some time to start on some other functionality which covers some of
the user stories which I have set for Sprint 3. 
### Sprint Retrospective
I managed to use my time much better than the previous sprint, taking into account there was more time to get things done as I didn't have an exam today. I did come across some small blocks mainly 
regarding the GUI however after doing some research I was able to solve these issues and in the process also learnt some more information about navigation windows.
I did spend some time in the evening working on the user stories but I also had to redo my Sparkhire video due to audio issues with the previous one, so this took some of my time which I had allocated.

## Sprint 3 03/12/2020
![image](https://github.com/Shaq10/GamingWPF/blob/main/Sprint3.png)
### Sprint Goal
- [x] Create new Customer from GUI
- [x] Create new Game from GUI
- [x] From the GUI, the user can delete a Game from the database
- [x] User can create Console from GUI
- [x] User can view all Customers
- [x] User can update Game details
### Sprint Review
I managed to complete all the stories which I planned for this sprint. I also had time to start working on other functionality related to user stories I plan to put in the next sprint
### Sprint Retrospective
My time was utilised well for this sprint. I had an issue regarding entering dates but after doing more research I figured out how to implement a date picker . I also learnt more about how navigation 
windows operate whilst trying to sort out my own navigation for the application. In hindsight I could have added more user stories to this Sprint as I didn't expect to complete everything so soon

## Sprint 4 04/12/2020
![image](https://github.com/Shaq10/GamingWPF/blob/main/Sprint4.png)
### Sprint Goal
- [x] Update Console details in GUI
- [x] Delete Console in database from GUI
- [x] Create Genre from GUI
- [x] Display all Orders made
- [x] Update Customer details from GUI
- [x] Delete Customer in database from GUI
- [x] Delete Genre in database from GUI

### Sprint Review
Again I completed all of the user stories which I planned to achieve. The majority of CRUD functionality was implemented for all of the tables and the pages are linking well which will improve the user experience. Some unit testing was also carried out to ensure that everything functions correctly and all tests pass

### Sprint Retrospective
I prioritised my user stories in a way which would allow me to spend more time in the morning on the more difficult tasks. I had a big blocker regarding an Order entry which takes two foreign keys however I managed to solve this after research and speaking with others who also had the exact same problem. In the next sprint I will complete all the function CRUD functionality remaining in the backlog 

## Sprint 5 05/12/2020
![image](https://github.com/Shaq10/GamingWPF/blob/main/Sprint5.png)

### Sprint Goal
- [x] Customer can place an order
- [x] Manager can delete pending orders
- [x] Customer can cancel orders
- [x] Validation user input in GUI
- [x] Orders can be updated (delivery date)

### Sprint Review
All tasks which I set out to complete were done. All CRUD functionality for each of the 5 tables has been implemented so I have achieved the MVP. In addition to this I have also improved the aesthetics of the GUI so that it has a nice layout and complimenting colours which make the user experience enjoyable

### Sprint Retrospective
Majority of the Tasks which were completed for this sprint were similar to other taks which I had done in the previous 2 sprints so it wasn't too difficult or time sonsuming to finish off this work. In order to
do the Order page as I intended, I learnt how to combine the values from two list boxes containing data from two separate tables.