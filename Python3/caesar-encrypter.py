
def caesar_encrypter(realText, step):
	outText = ""
	cryptText = []
	
	uppercase = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z']
	lowercase = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z']
	puncuation = [",","'",":","!","~","`","@","#","$","%","^","&","*","(",")","-","_","+","=","<",">","/","?",";","\\","|","{","}","[","]"]

	for eachLetter in realText:
		if eachLetter in uppercase:
			index = uppercase.index(eachLetter)
			crypting = (index + step) % 26
			#print("{}  index={} Crypt={}".format(eachLetter,index,crypting))
			cryptText.append(crypting)
			newLetter = uppercase[crypting]
			outText += (newLetter)
		elif eachLetter in lowercase:
			index = lowercase.index(eachLetter)
			crypting = (index + step) % 26
			#print("{}  index={} Crypt={}".format(eachLetter,index,crypting))
			cryptText.append(crypting)
			newLetter = lowercase[crypting]
			outText += (newLetter)
		elif eachLetter in puncuation:
		  outText += eachLetter 
		else:
		  outText += " "
	return outText

code = caesar_encrypt("attackat(onc)e ABCDEFGHIJKLMNOPQRSTUVWXYZ so how does it ain't work function(string) { alert('hello'); }" , 23)

print(code)





import numpy as np
from pydub import AudioSegment
from collections import OrderedDict 

def difference(a, b):
	if (a > 0) and (b > 0):
		return (abs(a - b))
	elif (a > 0) and (b < 0):
		return abs(a + abs(b))
	elif (a < 0) and (b < 0):
		return (abs(a) - abs(b))

def boxcounting(left_channel, right_channel, scale):
	ratioX = difference(max(left_channel), min(left_channel))/scale
	ratioY = difference(max(right_channel), min(right_channel))/scale
	startX = min(left_channel)
	count_per_scale = []
	countbox = 0
	pair = list(OrderedDict.fromkeys(list(zip(left_channel, right_channel)))) 

	for x in range(scale):
		print('startX',startX)
		startY = min(right_channel)
		endX = startX + ratioX
		if x == (scale-1):
			endX = max(left_channel)
		print('endX',endX)
		for y in range(scale):
			print('-----------------------')
			print('startY',startY)
			endY = startY + ratioY
			if y == (scale-1):
				endY = max(right_channel)
			print('endY',endY)
			count = 0 # reset
			for l,r in pair:
				if (startX < l <= endX):
					if (startY < r <= endY):
						count+=1
						print('0',l,r)
						print('count',count)
					elif (min(right_channel) == r and r == startY):
						count+=1
						print('1',l,r)
						print('count',count)
				elif (min(left_channel) == l and l == startX):
					if (startY < r <= endY):
						count+=1
						print('2',l,r)
						print('count',count)
					elif (min(right_channel) == r and r == startY):
						count+=1
						print('3',l,r)
						print('count',count)
			count_per_scale.append(count)
			if count != 0:
				countbox += 1
			startY = endY
		startX = endX
		print('===============================')
 
	print(count_per_scale)
	countbox = 0
	for i in count_per_scale:
		if(i > 0):
			countbox += 1
	countbox = np.count_nonzero(count_per_scale)
	print('No. of box that has value =', countbox)
	return countbox

sound = AudioSegment.from_file('Alpharock - Pump This Party.mp3') 
split_sound = sound.split_to_mono()
left_channel = np.array(split_sound[0].get_array_of_samples())
right_channel = np.array(split_sound[1].get_array_of_samples())
scale = 10 #norm and scale up
scaleupL = np.round((left_channel/np.abs(left_channel).max())* scale,1) 
scaleupR = np.round((right_channel/np.abs(right_channel).max())* scale,1) 
