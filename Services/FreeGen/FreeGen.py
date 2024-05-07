import numpy as np
import pandas as pd
import random
from fastapi import FastAPI, HTTPException
from fastapi.encoders import jsonable_encoder

app = FastAPI()

Names = pd.read_csv('Dataset.csv')
unique_categories = Names['Gender'].unique()
column_names = Names.columns.tolist()
columns_to_drop = ['Passenger ID', 'Airport Name', 'Airport Country Code', 'Airport Continent', 'Continents',
                   'Departure Date', 'Arrival Airport', 'Pilot Name', 'Flight Status', 'Country Name']
Names = Names.drop(columns=columns_to_drop)

@app.get("/get_result_array")
async def get_result_array():
    Ncolumns = ['First Name', 'Gender', 'Nationality']
    random_index = random.randint(0, len(Names) - 1)
    random_line = Names.loc[random_index, Ncolumns].values
    filtered_df = Names[Names['Nationality'] == random_line[2]]
    random_index2 = random.randint(0, len(filtered_df) - 1)
    random_last_name = filtered_df.iloc[random_index2]['Last Name']
    age_column = Names['Age']
    random_age = random.choice(age_column)

    result_array = [str(random_line[0]), str(random_last_name), str(random_line[1]), int(random_age), str(random_line[2])]
    return jsonable_encoder({"result_array": result_array})

if __name__ == "__main__":
    import uvicorn
    uvicorn.run(app, host="127.0.0.1", port=8000)