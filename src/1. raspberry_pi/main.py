from threading import Thread
import time

import socket_client
import camera
import conveyor
import sensor

def running():
	try:
		while True:
			time.sleep( 1 )
			if sensor.detected() == True:
				print( "detected" )

			recv_data = socket_client.recv()
			if recv_data == "START":
				print( "START" )
			elif recv_data == "CAPTURE":
				camera.capture()
			elif recv_data == "RUNNING":
				conveyor.run()

	except Exception as e:
		print( "except" )


if __name__ == "__main__":
    print( "main" )
    socket_client.connect( '127.0.0.1', 9999 )
    
    main_th = Thread( target=running )
    main_th.start()
    
    
	
 
