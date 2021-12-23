# Overview
The purpose of this project is to facilitate migrating from entity framework 6.0 to entity framework core (EFC). More specifically it provides tooling to transform EDMX files into EFC models.

It differs from current tooling that I have found which reverse engineer databases to create the model. This tooling converts the conceptual model in EDMX to the EFC model. In this way all changes made to the conceptual EDMX model are reflected in the EFC model. This includes:

 - Entity names
 - Property names
 - Added associations that do not exist in the database (especially useful for views)

This greatly facilitates upgrading large entity framework 6.0 models to EFC where a lot of effort has already gone into customizing the model.
# Usage
## Requirements
 1. The database must already exist. This tooling will not create an EFC model that will create a database for you.
 2. The tooling uses T4 templates in Visual Studio to create the model. It has only been tested in Visual Studio 2019.
## Create a Model
### Install the Project Template
Download the [*Edmx To Entity Framework Core*](https://github.com/boone34/Data.Entity.Edmx/blob/master/Assets/ProjectTemplates/Edmx%20To%20Entity%20Framework%20Core.zip) project template and install it in Visual Studio.

I have found that this can be done by copying the *Edmx To Entity Framework Core.zip* file to your *Documents\Visual Studio 2019\Templates\ProjectTemplates* folder and restarting Visual Studio. **Note:** I have found that it does not work if you copy it to a sub folder such as *Visual C#* but your mileage may differ.
### Create the Model Project
Create the model project using the *Edmx To Entity Framework Core* project template. Finding the template can be a little tedious using visual studio as you cannot search for it or use project type filters. Also project templates do not appear to be sorted in any particular order. So set project type filters to all and scroll until you find the project template.
![Project Selector](ProjectSelector.png)
# Nitty Gritty
