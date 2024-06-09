#include "stdafx.h"
#include "common.h"
#include <opencv2/opencv.hpp>
#include <opencv2/core/core.hpp>
#include <opencv2/core/utils/logger.hpp>

using namespace std;
using namespace cv;

int isInside(Mat img, int i, int j) {

	return i >= 0 && i < img.rows && j >= 0 && j < img.cols;
}

//functie care detecteaza daca un pixel este colt sau nu
bool isCorner(Mat_<uchar> img, int row, int col, int prag, int n)
{
	//deplasamentul relativ fata de pozitia pixelului central
	int deplX[] = { 0, 1, 2, 3, 3, 3, 2, 1, 0, -1, -2, -3, -3, -3, -2, -1 };
	int deplY[] = { -3, -3, -2, -1, 0, 1, 2, 3, 3, 3, 2, 1, 0, -1, -2, -3 };

	int dark = 0;
	int light = 0;

	for (int i = 0; i <= 26; i++) {//inainte aveam 0->15 pentru verificarea celor 16 vecini, 
		//dar acum am mai adaugat 11 pixeli, pentru a verifica si circular (de exemplu, pixelul 16 cu pixelii 1..11)
		if (isInside(img, row + deplX[i], col + deplY[i])) {
			//verificare mai inchis
			if ((img(row + deplX[i%16], col + deplY[i%16]) < (img(row, col) - prag))) {
				light = 0;
				dark++;
			}
			//verificare mai deschis
			else if ((img(row + deplX[i%16], col + deplY[i%16]) > (img(row, col) + prag))) {
				light++;
				dark = 0;
			}

			if (dark >= n || light >= n) {
				return true;
			}
		}
	}

	return false;
}

vector<Point2f> fastAlg(Mat_<uchar>img)
{
	vector<Point2f> points;
	int prag = 20;
	int n = 12;	//nr consecutiv de pixeli ca sa decidem daca un pixel e colt

	for (int i = 0; i < img.rows; i++) {
		for (int j = 0; j < img.cols; j++) {
			if (isCorner(img, i, j, prag, n)) {//este pixel colt
				points.push_back(Point2f(j, i));//pixel colt, coord se adauga in vectorul points
			}
		}
	}

	//AM ADAUGAT VERIFICAREA DE MAXIME LA COLTURI :)
	//gasesc maximul la colt, ca sa nu mai afisez asa multe puncte gasite in jurul coltului=>acuratete imbunatatita
	vector<Point2f> points_improved;//vector care va retine maximele din punctele gasite anterior ca fiind colturi
	float prag_puncte = 3.0;	//prag pt puncte apropiate, poate fi ajustat in functie de imagine si de precizia dorita
	
	for (int i = 0; i < points.size(); i++) {
		bool maxi = true;
		for (int j = 0; j < points.size(); j++) {
			if (i != j) {
				//calculez distanta euclidiana
				float dx = points[i].x - points[j].x;
				float dy = points[i].y - points[j].y;
				float dist = sqrt(dx * dx + dy * dy);
				if (dist < prag_puncte) {
					if (img(points[i].y, points[i].x) < img(points[j].y, points[j].x)) {
						maxi = false;
						break;
					}
				}
			}
		}
		if (maxi) {
			//adaugam in vector doar maximele
			points_improved.push_back(points[i]);
		}
	}

	return points_improved;	//vectorul returneaza colturile obtinute, dupa gasirea maximelor
	//return points;
}

//high-speed test, pentru respingerea punctelor care nu sunt colturi
bool isCornerFast(Mat_<uchar> img, int row, int col, int prag)
{
	int deplX[] = { 0, 1, 2, 3, 3, 3, 2, 1, 0, -1, -2, -3, -3, -3, -2, -1 };
	int deplY[] = { -3, -3, -2, -1, 0, 1, 2, 3, 3, 3, 2, 1, 0, -1, -2, -3 };

	int dark = 0;
	int light = 0;

	//se examineaza pixelii 1 si 9; daca I1 si I9 apartin intervalului => pixelul e colt
	if (isInside(img, row + deplX[1], col + deplY[1])) {
		//verificare vecin 1
		if ((img(row + deplX[1], col + deplY[1]) >= (img(row, col) - prag)) && (img(row + deplX[1], col + deplY[1]) <= (img(row, col) + prag))){
			if (isInside(img, row + deplX[9], col + deplY[9])) {
				//verificare vecin 9
				if ((img(row + deplX[9], col + deplY[9]) >= (img(row, col) - prag)) && (img(row + deplX[9], col + deplY[9]) <= (img(row, col) + prag))) {
					return false;
				}
			}
		}
	}

	int count_dark = 0;
	int count_light = 0;

	//se examineaza pixelii 1,5,9 si 13
	if (isInside(img, row + deplX[1], col + deplY[1])) {
		//verificare  vecin 1
		if ((img(row + deplX[1], col + deplY[1]) > (img(row, col) + prag))) {
			count_light++;
		}
		else if ((img(row + deplX[1], col + deplY[1]) < (img(row, col) - prag))) {
			count_dark++;
		}
	}

	if (isInside(img, row + deplX[5], col + deplY[5])) {
		//verificare  vecin 5
		if ((img(row + deplX[5], col + deplY[5]) > (img(row, col) + prag))) {
			count_light++;
		}
		else if ((img(row + deplX[5], col + deplY[5]) < (img(row, col) - prag))) {
			count_dark++;
		}
	}

	if (isInside(img, row + deplX[9], col + deplY[9])) {
		//verificare  vecin 9
		if ((img(row + deplX[9], col + deplY[9]) > (img(row, col) + prag))) {
			count_light++;
		}
		else if ((img(row + deplX[9], col + deplY[9]) < (img(row, col) - prag))) {
			count_dark++;
		}
	}

	if (isInside(img, row + deplX[13], col + deplY[13])) {
		//verificare  vecin 13
		if ((img(row + deplX[13], col + deplY[13]) > (img(row, col) + prag))) {
			count_light++;
		}
		else if ((img(row + deplX[13], col + deplY[13]) < (img(row, col) - prag))) {
			count_dark++;
		}
	}
	if (count_dark >= 3 || count_light >= 3) {
		return true;
	}

	return false;
}

vector<Point2f> fastAlg2(Mat_<uchar>img)
{
	vector<Point2f> points;
	int prag = 80;

	for (int i = 0; i < img.rows; i++) {
		for (int j = 0; j < img.cols; j++) {
			if (isCornerFast(img, i, j, prag)) {//este pixel colt
				points.push_back(Point2f(j, i));//pixel colt, coord se adauga in vectorul points
			}
		}
	}
	return points;	//vectorul returneaza colturile obtinute
}

void drawPoint(Mat& img, Point center, Scalar color, int thickness)//pentru desenare puncte 
{
	circle(img, center, thickness, color, -1);
}

void drawX(Mat& img, Point center, Scalar color, int thickness)//pentru desenare X 
{
	int lineLength = thickness * 5; 

	//deseneaza prima linie din diagonala
	line(img, Point(center.x - lineLength, center.y - lineLength), Point(center.x + lineLength, center.y + lineLength), color, thickness);

	//deseneaza a doua diagonala
	line(img, Point(center.x + lineLength, center.y - lineLength), Point(center.x - lineLength, center.y + lineLength), color, thickness);
}


Mat transform_grayscale_to_rgb(Mat img)//functie care converteste din grayscale in rgb
{
	Mat colored(img.rows, img.cols, CV_8UC3);

	for (int i = 0; i < img.rows; i++) {
		for (int j = 0; j < img.cols; j++) {
			uchar gray_val = img.at<uchar>(i, j);
			colored.at<Vec3b>(i, j) = (gray_val, gray_val, gray_val);
		}
	}
	return colored;
}

int main() {
	cv::utils::logging::setLogLevel(cv::utils::logging::LOG_LEVEL_FATAL);
	//Mat_<uchar>img = imread("Images/dreptunghi.png", IMREAD_GRAYSCALE);
	//Mat_<uchar>img = imread("Images/triangle_down.bmp", IMREAD_GRAYSCALE);
	//Mat_<uchar>img = imread("Images/p13.jpg", IMREAD_GRAYSCALE);
	//Mat_<uchar>img = imread("Images/star.bmp", IMREAD_GRAYSCALE);
	//Mat_<uchar>img = imread("Images/img.png", IMREAD_GRAYSCALE);
	Mat_<uchar>img = imread("Images/p3.jpeg", IMREAD_GRAYSCALE);
	vector<Point2f> points = fastAlg(img);

	Mat_<Vec3b> imgColor;
	cvtColor(img, imgColor, COLOR_GRAY2BGR);

	for (const auto& p : points) {
		printf("%f %f\n", p.x, p.y);
		drawPoint(imgColor, p, Scalar(233, 93, 191), 1);//BGR
	}


	imshow("initial image", img);
	imshow("corner detection", imgColor);


	//masurare timp pentru fast cu si fara high-speed test
	double t1 = (double)getTickCount();
	vector<Point2f> dst1 = fastAlg(img);
	t1 = ((double)getTickCount() - t1) / getTickFrequency();
	printf("Timp pentru segment test detector = %.3f [ms]\n", t1 * 1000);
	cout << endl;

	double t2 = (double)getTickCount();
	vector<Point2f> dst2 = fastAlg2(img);
	t2 = ((double)getTickCount() - t2) / getTickFrequency();
	printf("Timp cu high speed test = %.3f [ms]\n", t2 * 1000);

	waitKey();
	return 0;
}


