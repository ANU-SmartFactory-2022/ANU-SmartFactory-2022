import RPi.GPIO as GPIO
import time
from collections import deque
import sensor

GPIO.setwarnings(False)
GPIO.setmode(GPIO.BOARD)

AIN1=3
BIN1=7
AIN2=5
BIN2=11
con = 13

sig=deque([1,0,0,0])

GPIO.setup(AIN1,GPIO.OUT,initial=GPIO.LOW)
GPIO.setup(BIN1,GPIO.OUT,initial=GPIO.LOW)
GPIO.setup(AIN2,GPIO.OUT,initial=GPIO.LOW)
GPIO.setup(BIN2,GPIO.OUT,initial=GPIO.LOW)
GPIO.setup(con,GPIO.OUT,initial=GPIO.LOW)

def motor(s,r):
    t = int(s*5/9)
    for cnt in range(0,t):
        GPIO.output(AIN1,sig[0])
        GPIO.output(BIN1,sig[1])
        GPIO.output(AIN2,sig[2])
        GPIO.output(BIN2,sig[3])
        time.sleep(0.01)
        
        sig.rotate(r)

# global location
# location = 2

# 현재 위치 2, 정상=2, 버림=1, 수리가능=3,4
def moving(CLASSIFY_RESULT,now):
    Way = -1
#     global location
    
    if CLASSIFY_RESULT==4:
        CLASSIFY_RESULT=3
        
    move = CLASSIFY_RESULT - now
    if move<0:
        move = -move
        Way = 1

    if move != 0:
        motor(45*int(move),Way)
        
    now = CLASSIFY_RESULT
    return now
    
def run():
    GPIO.output(con,1)
    a = 0
    while sensor.distance_3()==0:
        time.sleep(0.1)
        a+=1
        if a>=25:
            GPIO.output(con,0)
            return 1
    
    GPIO.output(con,0)
    return 0
    
    