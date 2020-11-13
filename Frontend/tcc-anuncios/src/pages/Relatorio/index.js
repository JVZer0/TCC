import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Meus Favoritos/style.css';

import Logo from '../../assets/image/Capturar.PNG'
import '../Relatorio/style.css'

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();


export default function Home(props){

    const [infos, setInfos] = useState(props.location.state);

    return(
        <div className="eiei">
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to={{pathname: "/Home", state: infos}} ><img class="logo" src={Logo} src={Logo} width="180" height="34px" alt=''/></Link>
                </div>
            </div>

            <div class="tange">
                <Link to={{ pathname: "/RelatorioUm", state: infos}}><button className="botoxi">Relatorio Um</button></Link>
                <Link to={{ pathname: "/RelatorioDois", state: infos}}><button className="botoxi">Relatorio Dois</button></Link>   
                <Link to={{ pathname: "/RelatorioTres", state: infos}}><button className="botoxi">Relatorio Três</button></Link>
                <Link to={{ pathname: "/RelatorioQuatro", state: infos}}><button className="botoxi">Relatorio Quatro</button></Link>
                <Link to={{ pathname: "/RelatorioCinco", state: infos}}><button className="botoxi">Relatorio Cinco</button></Link>                
            </div>

            <div className="rodape">
                    <div className="tey">
                        <h4>Site criado pelo time TK Soluções de Informática. Todos os direitos reservados</h4>
                    </div>
            </div>
        </div>
    )
}