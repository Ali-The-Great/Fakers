FROM python:3
ADD FreeGen.py /
ADD "Dataset.csv" /
RUN pip install numpy pandas fastapi uvicorn
EXPOSE 8000
CMD ["uvicorn", "FreeGen:app", "--host", "0.0.0.0", "--port", "8000"]