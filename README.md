# VotingPolls
This a CRUD app for creating one-question polls, voting, checking the results and commenting on them.

## Technologies
* ASP.NET Core MVC
* Entity Framework Core
* AutoMapper
* Razor Pages
* Bootstrap.

## Features
* Create a poll
  * set the poll name, question and possible answers
  * choose whether your poll should be of multiple choice or not
  * allow or prohibit other users from adding new answers
* Edit your poll
  * poll question - only if no user has voted yet
  * answers - only if users haven't voted for a specific answer yet
* Delete your poll
* Share the poll link with your friends
  * every user who has visited your poll at least once will see it listed in the „shared with me” section
* Vote in a poll / change or delete the answers selected in a poll
* Check out the poll results
  * percentage bar to visualize each answer score
  * a list of users next to each answer showing who voted
* Leave comments under the poll results

## Sample Database
If you want to run this project on your machine, the app will apply the latest migrations on startup to set up the sample database. The template is configured to use SQL Server by default.

Use the sample user credentials:

* LOGIN: Benedict1@mail.com
* PASSWORD: Pwd#123
