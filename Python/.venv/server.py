from flask import Flask, request

app = Flask(__name__)


@app.route('/', methods=['POST'])
def upload_file():
    print(request)
    print(request.files)

    file = request.files['image']
    print(file)
    file.save('./image.png')
    return 'Image saved successfully'
