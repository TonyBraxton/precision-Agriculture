import numpy as np
from flask import Flask, request, jsonify
import joblib
import pandas as pd
from flask_cors import CORS  # Import CORS

# Load your models once when the server starts
model_THI = joblib.load('thi_model.pkl')
model_NBR = joblib.load('nbr_model.pkl')
model_WAI = joblib.load('wai_model.pkl')
model_PP = joblib.load('pp_model.pkl')
model_SFI = joblib.load('sfi_model.pkl')
model_Label = joblib.load('label_model.pkl')

# Load the LabelEncoder to decode predictions
label_encoder = joblib.load('label_encoder.pkl')  # Load the saved LabelEncoder

# Initialize Flask app
app = Flask(__name__)

CORS(app)  # Enable CORS for all routes


# Alternatively, if you want to allow only requests from your ASP.NET Core app (localhost:7400)
# CORS(app, resources={r"/*": {"origins": "http://localhost:7400"}})

@app.route('/predict', methods=['POST'])
def predict():
    # Get the input data from the request
    data = request.json
    # Create a DataFrame with the input values
    input_data = pd.DataFrame([data])

    # Predict the values using the appropriate model
    thi_prediction = model_THI.predict(input_data[['temperature', 'humidity']])
    nbr_prediction = model_NBR.predict(input_data[['N', 'P', 'K']])
    wai_prediction = model_WAI.predict(input_data[['soil_moisture', 'rainfall']])
    pp_prediction = model_PP.predict(input_data[['sunlight_exposure', 'co2_concentration', 'temperature']])
    sfi_prediction = model_SFI.predict(input_data[['organic_matter', 'N', 'P', 'K']])
    # Predict the label (encoded integer)
    label_prediction = model_Label.predict(input_data[['N', 'P', 'K', 'humidity', 'temperature', 'co2_concentration']])

    # Decode the predicted label (integer) to the original label (crop name)
    decoded_label = label_encoder.inverse_transform(label_prediction)

    print(input_data.columns)
    print(data)
    # Return the predictions as a JSON response
    return jsonify({
        'THI': thi_prediction[0],
        'NBR': nbr_prediction[0],
        'WAI': wai_prediction[0],
        'PP': pp_prediction[0],
        'SFI': sfi_prediction[0],
        'Label': decoded_label[0]  # Return the decoded crop name (not integer)
    })


if __name__ == '__main__':
    app.run(debug=True)
