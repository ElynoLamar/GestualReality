import subprocess
from flask import Flask, request, jsonify, make_response
import os
# from skimage import color
# from skimage import io


app = Flask(__name__)


@app.route('/', methods=['POST'])
def upload_file():
    file = request.files['image']
    filename = file.filename
    uploadFolder = 'uploads'
    print(filename)
    caminho = os.path.join(uploadFolder, filename)
    print(caminho)
    # file = color.rgb2gray(file)

    # io.imshow(file)
    # file.save(uploadFolder+'/image.png')
    print(caminho)
    command = 'python ./yolov5-master/detect.py --weights ./yolov5-master/weights/best.pt --device 1 --img 640 --conf 0.90 --source ' + caminho

    output = subprocess.getoutput(command)
    print(output)
    # d = {"teste": "E"}
    return "E"
