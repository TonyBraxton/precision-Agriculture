# precision Agriculture 

#NOTE: THIS IS STILL UNDERGOING REFINEMENTS


Precision Agriculture - Smart Crop Recommendation System
contributors: Tony Braxton Tchio Ngoumeza, Kalpan Patel
Database Systems
Project Timeline: Feb – Mar 2025

Project Summary
This project applies data mining and NoSQL database techniques to support precision agriculture. It recommends optimal crops and assesses environmental stress using real-world farming data (soil, weather, nutrients).

Key Deliverables
Data Collection

Public smart farming dataset

Domain problem: Crop recommendation & environmental analysis

Data Preprocessing:

-Handled missing values, normalized features, removed outliers

-Visualized data (histograms, boxplots, heatmaps)

-Balanced class distribution across 22 crop types

Database Design:

ER diagram with Crop, Weather, and Soil entities

Defined many-to-many relationships

NoSQL Implementation:

MongoDB with JSON schema and sharding for scalability

Data Mining:

Classification: Recommend crops with 94% accuracy

Regression: Predicted environmental indices (THI, NBR, SFI, etc.)

GUI:
As of now a simple interface C# Razor Page with html content Connected to NoSQL backend via Python API:
-displaying first 10 rows of each entity atble with added columns that compute Reression Indices
-(styled with CSS)
-js for API calls and interactivity


 
