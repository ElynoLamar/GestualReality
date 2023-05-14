import cv2
import numpy as np
import os

input_folder = "./images/"
output_folder = "./labels/"
# get list of image files in "./images/" directory
image_files = os.listdir(input_folder)

# loop through each image file
for file in image_files:
    if file.endswith(".jpg") or file.endswith(".png"):
        imagename = file
        file_name_without_ext = os.path.splitext(file)[0]
        first_letter = file_name_without_ext[0]
        classification = 0
        if (first_letter == "A"):
            classification = 0
        if (first_letter == "E"):
            classification = 1
        if (first_letter == "I"):
            classification = 2
        if (first_letter == "O"):
            classification = 3
        if (first_letter == "U"):
            classification = 4
        # read the input image
        img = cv2.imread(os.path.join(input_folder, imagename))

        # get image size
        height, width, _ = img.shape

        # convert to grayscale
        gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

        # threshold
        thresh = cv2.threshold(gray, 128, 255, cv2.THRESH_BINARY)[1]

        # get contours
        result = img.copy()
        contours = cv2.findContours(
            thresh, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
        contours = contours[0] if len(contours) == 2 else contours[1]

        # find bounding box of all contours
        bounding_box = None
        for cntr in contours:
            x, y, w, h = cv2.boundingRect(cntr)
            if bounding_box is None:
                bounding_box = (x, y, w, h)
            else:
                bx, by, bw, bh = bounding_box
                bounding_box = (min(x, bx), min(y, by), max(
                    x + w, bx + bw) - min(x, bx), max(y + h, by + bh) - min(y, by))

        # convert bounding box to YOLO format
        x_center = (bounding_box[0] + bounding_box[2] / 2) / width
        y_center = (bounding_box[1] + bounding_box[3] / 2) / height
        bbox_width = bounding_box[2] / width
        bbox_height = bounding_box[3] / height

        # write YOLO annotation to file
        output_path = os.path.join(
            output_folder, file_name_without_ext + '.txt')
        with open(output_path, 'w') as f:
            f.write(
                f"{classification} {x_center:.6f} {y_center:.6f} {bbox_width:.6f} {bbox_height:.6f}")
