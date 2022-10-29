import cv2

# img = cv2.imread( "qr_green.png" )
img = cv2.imread( "qr_green_err.png" )
# cv2.imshow('Test Image', img)

dst1 = cv2.inRange(img, (0, 0, 0), (0, 255, 0))

cv2.imshow('src', img)
cv2.imshow('dst1', dst1)

detect = cv2.QRCodeDetector()
value, points, straight_qrcode = detect.detectAndDecode(img)

print(value)
min = dst1.min()
if min < 255:
    print( "error!" ) 

cv2.waitKey(0)

# 이미지 윈도우 삭제
cv2.destroyAllWindows()
