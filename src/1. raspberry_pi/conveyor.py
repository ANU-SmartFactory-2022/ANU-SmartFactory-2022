import RPi.GPIO as GPIO
import time
from collections import deque
import sensor
from enum import Enum


AIN1=3
BIN1=7
AIN2=5
BIN2=11
con =21

sig=deque([1,0,0,0])

def INIT_2():
    GPIO.setwarnings(False)
    GPIO.setmode(GPIO.BOARD)
    GPIO.setup(AIN1,GPIO.OUT)
    GPIO.setup(BIN1,GPIO.OUT)
    GPIO.setup(AIN2,GPIO.OUT)
    GPIO.setup(BIN2,GPIO.OUT)
    GPIO.setup(con,GPIO.OUT,initial=GPIO.LOW)


class Position(Enum):
    TOP = 1
    MIDDLE = 2
    BOTTOM = 3

global currnet_pos
currnet_pos = Position.MIDDLE

def set_default_postion():
    moving(Position.MIDDLE)

def motor(Angle,Way):
    t = int(Angle*5/9)
    for cnt in range(0,t):
        GPIO.output(AIN1,sig[0])
        GPIO.output(BIN1,sig[1])
        GPIO.output(AIN2,sig[2])
        GPIO.output(BIN2,sig[3])
        time.sleep(0.02)
        
        sig.rotate(Way)

def moving( _position:Position ):
    global currnet_pos
    move_way = currnet_pos.value - _position.value
    motor( 45, move_way )
    currnet_pos = _position
    
def run():
    GPIO.output(con,1)

def stop():
    GPIO.output(con,0)

def step_end():
    GPIO.output(AIN1,0)
    GPIO.output(BIN1,0)
    GPIO.output(AIN2,0)
    GPIO.output(BIN2,0)
# 테스트용
try:
    INIT_2()
    sensor.INIT()
    global timer_work 
    global start_time 
    global end_time
    timer_work = False
    start_time = time.time()
    end_time = time.time()

    def timer_start():
        global start_time 
        global timer_work 
        timer_work = True
        start_time = time.time()

    def timer_check():
        global end_time
        global start_time 
        end_time = time.time()
        return end_time - start_time

    def timer_stop():
        global timer_work 
        timer_work = False

    def timer_working():
        global timer_work 
        return timer_work
    run()
    time.sleep(0.5)
    stop()
    time.sleep(0.5)
    moving(Position.TOP)
    time.sleep(2)

    run()
    timer_start()
    time.sleep(1)
    slide_sensor_state = sensor.slide_detect()

    if slide_sensor_state == 1:
        timer_stop()
        stop()
        print("1 end")
            
    working_time = timer_check()
    if timer_working() and working_time > 2:
        timer_stop()
        stop()
        print("2 end")

    time.sleep(3)
    stop()
    print("no")

    set_default_postion()
    step_end()
     

except KeyboardInterrupt:
    GPIO.cleanup()