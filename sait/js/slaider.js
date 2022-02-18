// Слайдер
function Sim(sldrId) {
	let id = document.getElementById(sldrId);

	if (id) {
		this.sldrRoot = id;
	}
	else {
		this.sldrRoot = document.querySelector('.slider');
	}

	// карусель
	this.sldrList = this.sldrRoot.querySelector('.slider-list');
	this.sldrElements = this.sldrList.querySelectorAll('.slider-element');
	this.sldrElemFirst = this.sldrList.querySelector('.slider-element');
	this.leftArrow = this.sldrRoot.querySelector('.arrow-left');
	this.righttArrow = this.sldrRoot.querySelector('.arrow-right');
	this.indicatorDots = this.sldrRoot.querySelector('.slider-dots');

	//инициализация
	this.options = Sim.default;
	Sim.initialize(this);
}

	Sim.default={
		loop: true,
		auto: true,
		interval: 5000,
		arrows: true,
		dots: true
	};

Sim.prototype.elemPrev = function (num)
{
	num = num || 1;

	let  prevElement = this.currentElement;
	this.currentElement -=num;

	if(this.currentElement < 0)
	{
		this.currentElement = this.elemCount - 1;
	}

	if(!this.options.loop)
	{
		if(this.currentElement === 0)
		{
			this.leftArrow.style.display = 'none';
		}
		this.rightArrow.style.display = 'block';
	}


	this.sldrElements[this.currentElement].style.opacity ='1';
	this.sldrElements[prevElement].style.opacity = '0';

	if(this.options.dots) {
		this.dotOn(prevElement);
		this.dotOff(this.currentElement);
	}

};

Sim.prototype.elemNext = function (num)
{
	num = num || 1;

	let prevElement = this.currentElement;
	this.currentElement +=num;

	if(this.currentElement >=this.elemCount) this.currentElement =0;

	if(!this.options.loop) {
		if (this.currentElement === this.elemCount - 1) {
			this.rightArrow.style.display = 'none';
		}
		this.leftArrow.style.display = 'block';
	}

	this.sldrElements[this.currentElement].style.opacity = '1';
	this.sldrElements[prevElement].style.opacity = '0';

	if(this.options.dots)
	{
		this.dotOn(prevElement);
		this.dotOff(this.currentElement);
	}

};

Sim.prototype.dotOn = function (num)
{
	this.indicatorDotsAll[num].style.cssText = 'background-color: #BBB; cursor: pointer;';

};

Sim.prototype.dotOff = function (num)
{
	this.indicatorDotsAll[num].style.cssText = 'background-color: #556; cursor: default;';
};

Sim.initialize = function (that)
{
	// константа
	that.elemCount = that.sldrElements.length;

	that.currentElement = 0;
	let bgTime = getTime();

	function getTime()
	{
		return new  Date().getTime();
	}

	function setAutoScroll()
	{
		that.autoScroll = setInterval(function ()
		{
			let fnTime = getTime();
			if(fnTime - bgTime + 10 > that.options.interval)
			{
				bgTime = fnTime;
				that.elemNext();
			}
		}, that.options.interval)
	}

	// начало инициализации
	if(that.elemCount <=1)
	{
		that.options.auto = false;
		that.options.arrows =false;
		that.options.dots = false;

		that.leftArrow.style.display='none';
		that.righttArrow.style.display='none';
	}

	if(that.elemCount >=1)
	{
		that.sldrElemFirst.style.opacity = '1';
	}

	if(!that.options.loop)
	{
		that.leftArrow.style.display = 'none';
		that.options.auto = false;
	}

	else if (that.options.auto)
	{
		setAutoScroll();

		// Остановка прокрутки при наведении мыши на элемент
		that.sldrList.addEventListener('mouseenter', function (){clearInterval(that.autoScroll)},false);
		that.sldrList.addEventListener('mouseleave', setAutoScroll, false)
	}

	// инициализация стрелок
	if(that.options.arrows)
	{
		that.leftArrow.addEventListener('click', function (){
			let fnTime = getTime();

			if(fnTime - bgTime > 1000)
			{
				bgTime = fnTime;
				that.elemPrev();
			}
		}, false);

		that.righttArrow.addEventListener('click', function (){

			let fnTime = getTime();

			if(fnTime - bgTime > 1000)
			{
				bgTime = fnTime;
				that.elemNext();
			}
		}, false)
	}
	else
	{
		that.leftArrow.style.display ='none';
		that.righttArrow.style.display = 'none';

	}

	// инициализация индикаторынх точек
	if(that.options.dots)
	{
		let sum ='', diffNum;
		for (let i=0; i<that.elemCount; i++)
		{
			sum+='<span class="sim-dot"></span>';
		}

		that.indicatorDots.innerHTML = sum;
		that.indicatorDotsAll = that.sldrRoot.querySelectorAll('span.sim-dot');

		// назначения точкам обработчика событий click
		for(let n=0; n<that.elemCount; n++)
		{
			that.indicatorDotsAll[n].addEventListener('click', function (){

				diffNum = Math.abs(n - that.currentElement);

				if(n< that.currentElement)
				{
					bgTime =getTime();
					that.elemPrev(diffNum);
				}
				else  if(n>that.currentElement){
					bgTime = getTime();
					that.elemNext(diffNum);
				}
			}, false);
		}

		that.dotOff(0);
		for (let  i=1; i<that.elemCount; i++)
		{
			that.dotOn(i);
		}
	}


};

new Sim();

// Вкладки
function Tab() {

	let tabs = function (target) {

		let _elemTabs = (typeof target === 'string' ? document.querySelector(target) : target),
			 _eventTabsShow;
			let _showTab = function (tabsLinkTarget) {
				let tabsPaneTarget, tabsLinkActive, tabsPaneShow;

				tabsPaneTarget = document.querySelector(tabsLinkTarget.getAttribute('href'));

				tabsLinkActive = tabsLinkTarget.parentElement.querySelector('.link-active');

				tabsPaneShow = tabsPaneTarget.parentElement.querySelector('.pane-show');

				// если слудующая вкладка равна активной, то завершаем работу
				if (tabsLinkTarget === tabsLinkActive) {
					return;
				}
				// Удаление классов у текущих активных элементов
				if (tabsLinkActive !== null) {
					tabsLinkActive.classList.remove('link-active');
				}
				if (tabsPaneShow !== null) {
					tabsPaneShow.classList.remove('pane-show');
				}
				// Добавляем классы к элементам
				tabsLinkTarget.classList.add('link-active');
				tabsPaneTarget.classList.add('pane-show');
				document.dispatchEvent(_eventTabsShow);
			},
			_switchTabTo = function (tabsLinkIndex) {
				let tabsLinks = _elemTabs.querySelectorAll('.tabs-link');

				if (tabsLinks.length > 0) {
					if (tabsLinkIndex > tabsLinks.length) {
						tabsLinkIndex = tabsLinks.length;
					} else if (tabsLinkIndex < 1) {
						tabsLinkIndex = 1;
					}

					_showTab(tabsLinks[tabsLinkIndex - 1]);
				}
			};

		_eventTabsShow = new CustomEvent('tab.show', {detail: _elemTabs});

		_elemTabs.addEventListener('click', function (e) {

			let tabsLinkTarget = e.target;

			// завершаем выполнение функции, если клик не по ссылке
			if (!tabsLinkTarget.classList.contains('tabs-link')) {
				return;
			}

			// отменяем стандартное действие
			e.preventDefault();
			_showTab(tabsLinkTarget);
		});

		return {
			showTab: function (target) {
				_showTab(target);
			},
			switchTabTo: function (index) {
				_switchTabTo(index);
			}
		}


	};
	 tabs('.tabs');

}

new Tab();

// Генерация товаров
function gentovar(imgsrc, idcont)
{

	for(let i=0; i<8; i++) {

		let panel = document.getElementById(idcont);


		let tovarA = document.createElement("a");

		tovarA.href = "Tovar.html";


		// Добавление id элемента
		tovarA.setAttribute('id', 'tovar1');


		let img_tovar = document.createElement("img");

		img_tovar.src = imgsrc +i+".jpg";


		let tov_title = document.createElement("div");

		tov_title.textContent = "Название товара";

		let tov_price = document.createElement("div");

		tov_price.textContent = "Цена товара";

		let tov_opic = document.createElement("div");

		tov_opic.textContent = "Описание товара";

		// Добавления класса элемента
		tovarA.classList.add("tovar");
		tov_title.classList.add("tovar_title");
		tov_price.classList.add("tovar_price");
		tov_opic.classList.add("tovar_opic");

		// Внедрение элемента в код
		panel.appendChild(tovarA);
		tovarA.appendChild(img_tovar);
		tovarA.appendChild(tov_title);
		tovarA.appendChild(tov_price);
		tovarA.appendChild(tov_opic);
	}

}
