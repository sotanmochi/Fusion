import imufusion
import matplotlib.pyplot as pyplot
import numpy
import sys

# Import sensor data
data = numpy.genfromtxt("sensor_data.csv", delimiter=",", skip_header=1)

timestamp = data[:, 0]
gyroscope = data[:, 1:4]
accelerometer = data[:, 4:7]

# Process sensor data
ahrs = imufusion.Ahrs()

for index in range(len(timestamp)):
    time = timestamp[index]
    gyro = gyroscope[index]
    accel = accelerometer[index]

    ahrs.update_no_magnetometer(gyro, accel, 1 / 100)  # 100 Hz sample rate
    euler = ahrs.quaternion.to_euler()

    print(f'')
    print(f'----------')
    print(f'Time: {time}')

    print(f'---')
    print(f'Gyroscope: ({gyro[0]}, {gyro[1]}, {gyro[2]})    ')
    print(f'Accelerometer: ({accel[0]}, {accel[1]}, {accel[2]})')

    print(f'---')
    print(f'Quaternion: ({ahrs.quaternion.w}, {ahrs.quaternion.x}, {ahrs.quaternion.y}, {ahrs.quaternion.z})')
    print(f'Euler: ({euler[0]}, {euler[1]}, {euler[2]})')
    print(f'---')
    print(f'')
    input('Press any key to process the next data...')
