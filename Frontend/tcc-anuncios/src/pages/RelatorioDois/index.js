import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Meus Favoritos/style.css';

import Logo from '../../assets/image/Capturar.PNG'

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();


export default function Home(props){

    const [infos, setInfos] = useState(props.location.state);
    const [anunciosMes, setAnunciosMes] = useState([]);

    const anunciosPorMes = async () => {
        const resp = await api.anunciosMes();
        setAnunciosMes(resp);
    }

    useEffect(() => {
        anunciosPorMes();
      }, []);


    return(
        <div className="eiei">
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to={{pathname: "/Relatorio", state: infos}} ><img class="logo" src={Logo} width="180" height="34px" alt=''/></Link>
                </div>
            </div>


            <div class="tabela1">
                <div className="shit1">
                    <table className="table">
                        <thead>
                            <tr>
                                <th>Mês</th>
                                <th>Qtd. Anuncios</th>
                                <th>Total Anuncios</th>
                            </tr>
                        </thead>

                        <tbody>
                            {anunciosMes.map(x =>
                                <tr>
                                    <td>{x.mes}</td>
                                    <td>{x.qtdAnuncios}</td>
                                    <td>{x.somaDosPrecoDosAnuncios}</td>
                                </tr>
                            )}      
                        </tbody>
                    </table>
                </div>
            </div>

            <div className="rodape">
                    <div className="tey">
                        <h4>Site criado pelo time TK Soluções de Informática. Todos os direitos reservados</h4>
                    </div>
            </div>
        </div>
    )
}