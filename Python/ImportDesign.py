import sys
import getopt
import GameEvents
import GameDialogs
import GameChapters
import Enum

#Sheets
Events = 0
Dialogs = 1
InteractingObject = 2
Chapters = 3

path = '../Design/Time.xls'

#JSON creation
JsonOutput = '/MainProject/Assets/Resources/Configurations/'

#Type Safe Enum Creation
TypeSafeEnumOutput = '/MainProject/Assets/Scripts/TypeSafeEnums/'
TemplateInteractingObjectScriptName = 'InteractingObjectEnum'
TemplateEventsScriptName = 'ObjectEnum'
TemplateEnumEventName = 'Events'
TemplateEnumInteracingObjectName = 'InteractingObject'

def main(argv):
	export = bool(0)
	updateEnum = bool(0)
	events = bool(0)
	dialogs = bool(0)
	interacting = bool(0)
	chapters = bool(0)

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
		elif arg == "chapters":
			chapters = bool(1)
		elif arg == "all":
			export = bool(1)
			updateEnum = bool(1)
			events = bool(1)
			dialogs = bool(1)
			interacting = bool(1)
			chapters = bool(1)

	if events:
		UpdateEvents(export, updateEnum)
	if dialogs:
		UpdateDialogs(export)
	if interacting:
		UpdateInteractingObjects(updateEnum)
	if chapters:
		UpdateChapters(export)		

def UpdateChapters(exportJson):
	if exportJson:
		GameChapters.Export(path, Chapters, JsonOutput);
		print('GameChapters.Export')
	pass

def UpdateEvents(exportJson, updateEnum):
	if exportJson or updateEnum:
		GameEvents.Export(path, Events, JsonOutput)
		print('GameEvents.Export')
	if updateEnum:
		Enum.Create(path, Events, TypeSafeEnumOutput, TemplateEventsScriptName, TemplateEnumEventName)
		print('Enum.Create')
	pass

def UpdateDialogs(exportJson):
	if exportJson:
		GameDialogs.Export(path, Dialogs, JsonOutput)
		print('GameDialogs.Export')
	pass	

def UpdateInteractingObjects(updateEnum):
	if updateEnum:
		Enum.Create(path, InteractingObject, TypeSafeEnumOutput, TemplateInteractingObjectScriptName, TemplateEnumInteracingObjectName)
		print('Enum.Create')
	pass

if __name__ == "__main__":
   main(sys.argv[1:])