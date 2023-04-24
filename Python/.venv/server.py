import subprocess
from flask import Flask, request, jsonify, make_response
import os

app = Flask(__name__)


@app.route('/', methods=['POST'])
def upload_file():
    file = request.files['image']
    filename = file.filename
    uploadFolder = 'uploads'
    caminho = os.path.join(uploadFolder, filename)
    command = 'python ./ultralytics/yolov8/test.py ' + caminho
    output = subprocess.getoutput(command)
    return output
