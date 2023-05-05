
from flask import Flask, request, jsonify, make_response
import os
import sys

app = Flask(__name__)

UPLOAD_FOLDER = '../uploads'
if not os.path.exists(UPLOAD_FOLDER):
    os.makedirs(UPLOAD_FOLDER)

# Add the path to the ultralytics directory to the Python module search path
sys.path.append(os.path.abspath(os.path.join(
    os.path.dirname(__file__), '..', 'ultralytics')))

# Import the my_function from test.py module


from yolov8.test import my_function

@app.route('/', methods=['POST'])
def upload_file():
    file = request.files['image']
    filename = file.filename
    filename = os.path.basename(filename)
    filepath = os.path.abspath(os.path.join(
        os.path.dirname(__file__), UPLOAD_FOLDER, filename))
    file.save(filepath)
    output = my_function(filepath)  # call the function directly
    print(output)
    return output
