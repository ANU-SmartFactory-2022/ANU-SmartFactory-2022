import RPi.GPIO as GPIO
import time

m = 19
n = 21

def INIT():
    GPIO.setwarnings(False)
    GPIO.setmode(GPIO.BOARD)

    GPIO.setup(m, GPIO.IN)
    GPIO.setup(n, GPIO.IN)

def start_pos_detect():
    return GPIO.input(m)

def slide_detect():
    return GPIO.input(n)
    

# try:
#     INIT()
    
#     print(start_pos_detect())
#     print(slide_detect())
# except Exception as e:
#     print( type(e) )
#     print(e)

GPIO.cleanup()
