

def capture():
    
    import cv2
    import time
    from picamera import PiCamera
    from time import sleep

    camera = PiCamera()

    #카메라 해상도
    camera.resolution = (2592, 1944)
    camera.framerate = 15

    #사진 촬영
    camera.start_preview()
    sleep(1)
    camera.capture('1.jpg')
    camera.stop_preview()
            
    # 사진 QR읽기
    img = cv2.imread('1.jpg') # 사진 읽기
    det = cv2.QRCodeDetector()      # QR 스캔 클래스
    info, box_coordinates, _ = det.detectAndDecode(img)

    if box_coordinates is None:     # 스캔결과 유무
        print('No Code')
    else:
        print(info)                 # 스캔결과 출력
