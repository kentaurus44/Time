import sys
import getopt
import GameEvents
import GameDialogs
import TypeSafeEnum

#Sheets
Events = 0
Dialogs = 1
InteractingObject = 2

path = '../Design/Time.xls'

#JSON creation
JsonOutput = '/MainProject/Assets/Resources/Configurations/'

#Type Safe Enum Creation
TypeSafeEnumOutput = '/MainProject/Assets/Scripts/TypeSafeEnums/'
TemplateInteractingObjectScriptName = 'InteractingObjectEnum'
TemplateEventsScriptName = 'ObjectEnum'


def main(argv):
	export = bool(0)
	updateEnum = bool(0)
	events = bool(0)
	dialogs = bool(0)
	interacting = bool(0)

	for arg in sys.argv:
		if arg == "ImportDesign.py":
			nothingHappensHere = ''
		elif arg == "export":
			export = bool(1)
		elif arg == "updateEnum":
			updateEnum = bool(1)
		elif arg == "events":
			events = bool(1)
		elif arg == "dialogs":
			dialogs = bool(1)
		elif arg == "interacting":
			interacting = bool(1)
		elif arg == "all":
			export = bool(1)
			updateEnum = bool(1)
			events = bool(1)
			dialogs = bool(1)
			interacting = bool(1)

	if events:
		UpdateEvents(export, updateEnum)
	if dialogs:
		UpdateDialogs(export)
	if interacting:
		UpdateInteractingObjects(updateEnum)

def UpdateEvents(exportJson, updateEnum):
	if exportJson or updateEnum:
		GameEvents.Export(path, Events, JsonOutput)
		print('GameEvents.Export')
	if updateEnum:
		TypeSafeEnum.Create(path, Events, TypeSafeEnumOutput, TemplateEventsScriptName)
		print('TypeSafeEnum.Create')

def UpdateDialogs(exportJson):
	if exportJson:
		GameDialogs.Export(path, Dialogs, JsonOutput)
		print('GameDialogs.Export')

def UpdateInteractingObjects(updateEnum):
	if updateEnum:
		TypeSafeEnum.Create(path, InteractingObject, TypeSafeEnumOutput, TemplateInteractingObjectScriptName)
		print('TypeSafeEnum.Create')

if __name__ == "__main__":
   main(sys.argv[1:])