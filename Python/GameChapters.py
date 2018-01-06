import xlrd
from collections import OrderedDict
import simplejson as json

#Constants
ChapterOutputFileName = 'Chapters.json'
ChapterKey = 'Chapter'
ChapterEvents = 'Events'
ChapterContainerKey = 'Chapters'

#Columns
ChapterName = 0

def Export(path, page, output):
	wb = xlrd.open_workbook(path)
	# Open the workbook and select the first worksheet
	sh = wb.sheet_by_index(page)

	chapters = []

	for col in range(0, sh.ncols):
		#create
		chapter = OrderedDict()
		chapter[ChapterKey] = sh.cell(ChapterName, col).value

		events = []
		for row in range(1, sh.nrows):
			event = sh.cell(row, col).value
			if event != '':
				events.append(event)
		chapter[ChapterEvents] = events
		chapters.append(chapter)

	gameChapters = OrderedDict()
	gameChapters[ChapterContainerKey] = chapters

	# Serialize the list of dicts to JSON
	j = json.dumps(gameChapters, sort_keys=True, indent=4)

	# Write to file
	with open('../' + output + ChapterOutputFileName, 'w') as f:
	    f.write(j)